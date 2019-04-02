using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
using DevExpress.Data.Filtering;
using Katrin.Services.Metadata;

namespace Katrin.Services.Notification
{
    public class FilterCriteriaHelper
    {
        private Guid _entityTypeId;
        Dictionary<string, object> _variablesValues;
        Dictionary<string, object> _oldValue;
        public FilterCriteriaHelper(Dictionary<string, object> oldValue,Guid entityTypeId)
        {
            _entityTypeId = entityTypeId;
            _oldValue = oldValue;
        }

        public FilterCriteriaHelper(Guid entityTypeId, Dictionary<string, object> variablesValues)
        {
            _entityTypeId = entityTypeId;
            _variablesValues = variablesValues;
        }

        public CriteriaOperator GeneratrCriteria(Criterion filterCondition)
        {
            List<CriteriaNode> criteriaNodeList = filterCondition.CriteriaNodes.ToList() as List<CriteriaNode>;
            if (criteriaNodeList.Count() <= 0) return null;
            CriteriaNode root = criteriaNodeList.Where(c => c.ParentNodeId == Guid.Empty).First();
            return GeneratrNode(root, criteriaNodeList);
        }

        private CriteriaOperator GeneratrNode(CriteriaNode node, List<CriteriaNode> criteriaNodeList)
        {
            if (node.Operator == "Group")
            {
                GroupOperator gOperator = GetGroupOperator(node);
                var subNodes = criteriaNodeList.Where(c => c.ParentNodeId == node.CriteriaNodeId);
                foreach (var subNode in subNodes)
                {
                    gOperator.Operands.Add(GeneratrNode(subNode, criteriaNodeList));
                }
                return gOperator;
            }
            else if(node.Operator == "Binry" || node.Operator == "TimeCompare")
            {
                return GetBinaryOperator(node);
            }
            return null;
        }

        private GroupOperator GetGroupOperator(CriteriaNode node)
        {
            GroupOperator theOperator = new GroupOperator();
            if (node.OperatorType == "And")
                theOperator.OperatorType = GroupOperatorType.And;
            else if (node.OperatorType == "Or")
                theOperator.OperatorType = GroupOperatorType.Or;
            return theOperator;
        }

        public Dictionary<string, object> GetEntityValue(string entityName,Dictionary<string, object> subVarables)
        {
            if (subVarables.Keys.Contains(entityName) && subVarables[entityName] is Dictionary<string, object>)
                return subVarables[entityName] as Dictionary<string, object>;
            foreach (var item in subVarables)
            {
                if (item.Value is Dictionary<string, object>)
                {
                    Dictionary<string, object> varables = item.Value as Dictionary<string, object>;
                    return GetEntityValue(entityName, varables);
                }
            }
            return null;
        }

        private Guid GetEntityId(Entity entity, EntityAttribute att)
        {
            Guid entityId = Guid.Empty;
            Dictionary<string, object> values = GetEntityValue(entity.PhysicalName, _variablesValues);
            if (values == null && att.PhysicalName.EndsWith("Id")) 
                values = GetEntityValue(att.PhysicalName.Substring(0, att.PhysicalName.Length -2), _variablesValues);
            if (values == null  &&  _variablesValues.Values.Count() > 0)
                values = _variablesValues.Values.First() as Dictionary<string, object>;
            if (values != null && values.Keys.Contains(att.PhysicalName))
            {
                object entityValue = values[att.PhysicalName];
                if (entityValue is Guid)
                    entityId = (Guid)entityValue;
            }
           
            return entityId;
        }

        private BinaryOperator GetBinaryOperator(CriteriaNode node)
        {
            BinaryOperator theOperator = new BinaryOperator();
            BinaryOperatorType operatorType;
            Enum.TryParse<BinaryOperatorType>(node.OperatorType,out operatorType);
            if(operatorType == null)
                operatorType = BinaryOperatorType.Equal;
            theOperator.OperatorType = operatorType;
            var entityInfo = MetadataProvider.Instance.EntiyMetadata
                .Where(c => c.EntityId == _entityTypeId).First();
            EntityAttribute att = entityInfo.Attributes
                .Where(d => d.AttributeId == node.CompareAttributeId).First();
            if (node.Operator == "TimeCompare" && att.AttributeType.Description == "datetime")
            {
                theOperator.LeftOperand = ConstantValue.Parse(att.TableColumnName);
                theOperator.RightOperand = new ConstantValue(DateTime.Today.AddDays(int.Parse(node.CompareValue)));
            }
            else
            {
                theOperator.LeftOperand = ConstantValue.Parse(att.TableColumnName);
                if (string.IsNullOrEmpty(node.CompareValue) && operatorType != BinaryOperatorType.NotEqual && att.AttributeType.Description == "uniqueidentifier")
                {
                    Guid entityId = GetEntityId(entityInfo, att);
                    theOperator.RightOperand = new ConstantValue(entityId);
                }
                else if (string.IsNullOrEmpty(node.CompareValue) && operatorType == BinaryOperatorType.NotEqual && _oldValue != null && _oldValue.Keys.Contains(att.PhysicalName))
                {
                    theOperator.RightOperand = new ConstantValue(GetValue(att.AttributeType, _oldValue[att.PhysicalName].ToString()));
                }
                else
                {
                    theOperator.RightOperand = new ConstantValue(GetValue(att.AttributeType, node.CompareValue));
                }
            }
            return theOperator;
        }

        private object GetValue(AttributeType aType, string compareValue)
        {
            if (aType.Description == "bit")
                return bool.Parse(compareValue);
            else if (aType.Description == "uniqueidentifier" || aType.Description == "lookup")
                return string.IsNullOrEmpty(compareValue) ? Guid.Empty : Guid.Parse(compareValue);
            else if (aType.Description == "int" || aType.Description == "picklist")
                return string.IsNullOrEmpty(compareValue) ? 0 : int.Parse(compareValue);
            else
                return compareValue;
        }
    }
}
