using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Katrin.Services.Metadata;
using DevExpress.Data.Filtering;
using Microsoft.Data.Edm;
using Antlr4.StringTemplate;
using System.Threading;


namespace Katrin.Services.Notification
{
    public class CreateNotification
    {
        public static void StartCreateCommonAttention()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(o =>
                {
                    CreateCommonNotification();
                });
        }

        public static void CreateCommonNotification(Guid entityId, string entityName, string aboutEntityName, 
            Guid operatorUserId, Dictionary<string, object> oldValue, int languageId)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(o =>
            {
                var aboutEntityTypeId = Guid.Empty;
                if (!string.IsNullOrEmpty(aboutEntityName))
                    aboutEntityTypeId = MetadataProvider.Instance.EntiyMetadata.Where(c => c.Name == aboutEntityName).First().EntityId;
                var entititys = MetadataProvider.Instance.EntiyMetadata.Where(c => c.Name == entityName);
                if (entititys.Count() <= 0) return;
                var entityTypeId = entititys.First().EntityId;
                var configs = MetadataProvider.Instance.NotificationProfileList.Where(c => c.IsSys == false);
                if (configs.Count() <= 0) return;
                foreach (var config in configs)
                {
                    if (aboutEntityTypeId != Guid.Empty)
                    {
                        var variables = MetadataProvider.Instance.MetadataServiceClient.GetNotificationVariablesById(config.ProfileVariables.First()
                            .NotificationVariable.NotificationVariableId);
                        if (variables.Where(c => c.EntityId == aboutEntityTypeId).Count() > 0 && variables.Where(c => c.EntityId == entityTypeId).Count() > 0)
                        {
                            ProcessOneEntity(config, null, entityId, operatorUserId, aboutEntityName, oldValue, languageId, false);
                        }
                    }
                    else if (config.ProfileVariables.First().NotificationVariable.EntityId == entityTypeId)
                    {
                        ProcessOneEntity(config, null, entityId, operatorUserId, aboutEntityName, oldValue, languageId, false);
                    }
                }
            });
        }
        public static void CreateCommonNotification()
        {

            DbContext commonContext = DynamicModelBuilder.CreateDataSource();
            if (commonContext == null) return;
            var configs = MetadataProvider.Instance.NotificationProfileList.Where(c=>c.IsSys == true);
            if (configs.Count() <= 0) return;
            foreach (NotificationProfile config in configs)
            {
                ProcessOneEntity(config, commonContext, Guid.Empty, Guid.Empty, string.Empty, null, 2052,true);
            }
        }

        private static void ProcessOneEntity(NotificationProfile config, DbContext commonContext, 
            Guid entityId, Guid operatorUserId, string relationEntityName
            , Dictionary<string, object> oldValue, int languageId,bool isSys)
        {
            if (commonContext == null) commonContext = DynamicModelBuilder.CreateDataSource();
            var entityInfo = MetadataProvider.Instance.EntiyMetadata.Where(c => c.EntityId == config.ProfileVariables.First().NotificationVariable.EntityId).First();
            var entityTypeId = entityInfo.EntityId;
            FilterCriteriaHelper helper = new FilterCriteriaHelper(oldValue,entityTypeId);
            CriteriaOperator theOperator = helper.GeneratrCriteria(config.Criterion);
            
            string primaryKey = string.Empty;
            primaryKey = entityInfo.Attributes.Where(c => c.IsPKAttribute == true).First().TableColumnName;

            Type entityInfoType = DynamicTypeBuilder.Instance.GetDynamicType(entityInfo.Name);

            //fetch data
            if (entityId != Guid.Empty)
            {
                theOperator = new GroupOperator(GroupOperatorType.And, theOperator, GetKeyOperator(entityId, primaryKey));
            }
            IQueryable query = commonContext.Set(entityInfoType).AsQueryable();
            try
            {
                System.Linq.Expressions.Expression expression = GetExpression(query, theOperator);
                query = query.Provider.CreateQuery(expression);
                IEnumerator iter = query.GetEnumerator();
                var tempEntityList = new ArrayList();
                while (iter.MoveNext())
                {
                    tempEntityList.Add(iter.Current);
                }
                Type attentionType = DynamicTypeBuilder.Instance.GetDynamicType("Notification");
                var entityList = new ArrayList();

                foreach (var item in tempEntityList)
                {
                    bool isExist = false;
                    if (entityId == Guid.Empty && isSys)
                    {
                        IQueryable notificationQuery = commonContext.Set(attentionType).AsQueryable();
                        BinaryOperator binaryOperator = new BinaryOperator();
                        binaryOperator.OperatorType = BinaryOperatorType.Equal;
                        binaryOperator.LeftOperand = ConstantValue.Parse("ObjectId");
                        binaryOperator.RightOperand = (Guid)item.GetType().GetProperty(primaryKey).GetValue(item, null);
                        System.Linq.Expressions.Expression attentionException = GetExpression(notificationQuery, binaryOperator);
                        notificationQuery = notificationQuery.Provider.CreateQuery(attentionException);
                        IEnumerator notificationIter = notificationQuery.GetEnumerator();

                        while (notificationIter.MoveNext())
                        {
                            if (notificationIter.Current != null)
                            {
                                isExist = true;
                                continue;
                            }
                        }
                    }
                    if (!isExist) entityList.Add(item);
                }
                if (entityList.Count <= 0) return;
                CreateNotificationItem(entityList, primaryKey, entityInfo.Name, config, operatorUserId, relationEntityName, oldValue, languageId);
            }
            catch
            {

            }
        }

        private static void CreateNotificationItem(IEnumerable entityList, string primaryKey, string entityName, 
            NotificationProfile config,Guid operatorUserId,string relationEntityName
            , Dictionary<string, object> oldValue, int languageId)
        {
            DbContext context = DynamicModelBuilder.CreateDataSource();
            
            foreach (var entityDataItem in entityList)
            {
                ProcessOneEntityData(entityDataItem, primaryKey, entityName, context, config, operatorUserId, relationEntityName, oldValue, languageId);
            }
            context.SaveChanges();
        }


        private static Dictionary<string, object> GetVariablesValues(List<NotificationVariable> notificationVariables,Guid entityId,
            string relationEntityName, ref Guid relationId, Dictionary<string, object> oldValue, int languageId)
        {
            DbContext context = DynamicModelBuilder.CreateDataSource();
            Dictionary<string, object> values = new Dictionary<string, object>();
            NotificationVariable rootVariable = notificationVariables.Where(c => c.ParentId == Guid.Empty).First();
            ProcessOneVariable(rootVariable, entityId, context, notificationVariables, values, relationEntityName, ref relationId, oldValue, languageId);
            return values;
        }

        private static void ProcessOneVariable(NotificationVariable variableNode, Guid entityId, DbContext context, List<NotificationVariable> notificationVariables, 
            Dictionary<string, object> values, string relationEntityName, 
            ref Guid relationId, Dictionary<string, object> oldValue, int languageId)
        {
            var entityInfo = MetadataProvider.Instance.EntiyMetadata.Where(c => c.EntityId == variableNode.EntityId).First();
            Type entityType = DynamicTypeBuilder.Instance.GetDynamicType(entityInfo.PhysicalName);
            if (!string.IsNullOrEmpty(relationEntityName) && relationEntityName == entityInfo.PhysicalName)
            {
                relationId = entityId;
            }
            IQueryable query = context.Set(entityType).AsQueryable();
            BinaryOperator binaryOperator = new BinaryOperator();
            binaryOperator.OperatorType = BinaryOperatorType.Equal;
            binaryOperator.LeftOperand = ConstantValue.Parse(entityInfo.Attributes.Where(c => c.IsPKAttribute == true).First().TableColumnName);
            binaryOperator.RightOperand = entityId;
            System.Linq.Expressions.Expression exception = GetExpression(query, binaryOperator);
            query = query.Provider.CreateQuery(exception);
            IEnumerator iter = query.GetEnumerator();
            object currentObject = null;
            int iterIndex = 0;
            while (iter.MoveNext())
            {
                if (iter.Current != null && iterIndex == 0) currentObject = iter.Current;
                iterIndex++;
            }
            if (currentObject == null) return;
            Dictionary<string, object> properValueList = new Dictionary<string, object>();
            foreach (var att in entityInfo.Attributes)
            {
                System.Reflection.PropertyInfo pro = currentObject.GetType().GetProperty(att.PhysicalName);
                if (pro == null) continue;
                var proValue = pro.GetValue(currentObject, null);
                if (att.OptionSet != null)
                {
                    if (proValue != null && !string.IsNullOrEmpty(proValue.ToString()))
                    {
                        var picValue = att.OptionSet.AttributePicklistValues.Where(c => c.Value == int.Parse(proValue.ToString())).First();
                        var labelValue = MetadataProvider.Instance.LocalizedLabels.Where(c => c.ObjectId == picValue.AttributePicklistValueId && c.LanguageId == languageId);
                        if(labelValue.Count() <= 0)
                            labelValue = MetadataProvider.Instance.LocalizedLabels.Where(c => c.ObjectId == picValue.AttributePicklistValueId);
                        var lable = labelValue.First();
                        proValue = lable.Label;
                    }

                    if (oldValue != null && oldValue.Keys.Contains(att.PhysicalName))
                    {
                        var oldV = oldValue[att.PhysicalName];
                        if (oldV != null && !string.IsNullOrEmpty(oldV.ToString()))
                        {
                            var picValue = att.OptionSet.AttributePicklistValues.Where(c => c.Value == int.Parse(oldV.ToString())).First();
                            var labelValue = MetadataProvider.Instance.LocalizedLabels.Where(c => c.ObjectId == picValue.AttributePicklistValueId && c.LanguageId == languageId);
                            if (labelValue.Count() <= 0)
                                labelValue = MetadataProvider.Instance.LocalizedLabels.Where(c => c.ObjectId == picValue.AttributePicklistValueId);
                            var lable = labelValue.First();
                            properValueList.Add("Old" + att.PhysicalName, lable.Label);
                        }
                    }
                }
                properValueList.Add(att.PhysicalName, proValue);
            }
            values.Add(entityInfo.PhysicalName, properValueList);
            var subVariables = notificationVariables.Where(c => c.ParentId == variableNode.NotificationVariableId);
            foreach (var subNode in subVariables)
            {
                var relatedAtt = entityInfo.Attributes.Where(c => c.AttributeId == subNode.RelatedAttributeId).FirstOrDefault();
                if (relatedAtt == null) continue;
                Guid subEntityId = (Guid)properValueList[relatedAtt.PhysicalName];
                ProcessOneVariable(subNode, subEntityId, context, notificationVariables, properValueList, relationEntityName, ref relationId, oldValue, languageId);
            }
        }


        public static string BuildTemplate(string template, IDictionary<string, object> data)
        {
            //, string dateFormat, string decimalFormat, IFormatProvider provider
            //Antlr4.StringTemplate.Template
            
            Template st = new Template(template, '$', '$');
            //VariableRenderer rendrer = new VariableRenderer("{0:yy/MM/dd}", "{0:0.00}", new FormatProvider());
            //st.Group.RegisterRenderer(typeof(int), rendrer);
            //st.Group.RegisterRenderer(typeof(String), rendrer);
            //st.Group.RegisterRenderer(typeof(Decimal), rendrer);
            //st.Group.RegisterRenderer(typeof(Double), rendrer);
            //st.Group.RegisterRenderer(typeof(DateTime), rendrer);
            //st.Group.RegisterRenderer(typeof(bool), rendrer);
            //st.Group.RegisterRenderer(typeof(float), rendrer);
            foreach (KeyValuePair<string, object> kvp in data)
            {
                st.Add(kvp.Key, kvp.Value);
            }
            return st.Render();
        }

        private static void ProcessOneEntityData(object entityDataItem, string primaryKey, string entityName,
            DbContext context,NotificationProfile config,Guid operatorUserId,string relationEntityName
            , Dictionary<string, object> oldValue, int languageId)
        {

            string templet = config.NotificationTemplate.SubjectTemplate;
            List<NotificationVariable> notificationVariables = MetadataProvider.Instance.MetadataServiceClient.GetNotificationVariablesById(config.ProfileVariables.First().NotificationVariable.NotificationVariableId);
            Type recipientType = DynamicTypeBuilder.Instance.GetDynamicType("NotificationRecipient");
            Type notificationType = DynamicTypeBuilder.Instance.GetDynamicType("Notification");

            object notificationInfo = Activator.CreateInstance(notificationType);
            Guid notificationId = Guid.NewGuid();
            SetPropertyValue(notificationInfo, "NotificationId", notificationId);

            Guid objectId = (Guid)GetPropertyValue(entityDataItem, primaryKey);
            SetPropertyValue(notificationInfo, "ObjectId", objectId);
           

            Guid relationId = Guid.Empty;
            Dictionary<string, object> variablesValues = GetVariablesValues(notificationVariables, objectId, relationEntityName, ref relationId, oldValue, languageId);

            if (config.SubjectTemplateId != null && config.SubjectNotificationTemplate != null)
            {
                string subjectTemplet = config.SubjectNotificationTemplate.SubjectTemplate;
                SetPropertyValue(notificationInfo, "Subject", BuildTemplate(subjectTemplet,variablesValues));
            }
            else
            {
                SetPropertyValue(notificationInfo, "Subject", entityName);
            }

            SetPropertyValue(notificationInfo, "Body", BuildTemplate(templet, variablesValues));
            string notificationUrl = entityName + "#" + objectId;

            string objectType = entityName;
            if (!string.IsNullOrEmpty(relationEntityName) && relationEntityName != entityName && relationId != Guid.Empty)
            {
                notificationUrl = relationEntityName + "#" + relationId;
                objectType = entityName + "-" + relationEntityName;
            }
            SetPropertyValue(notificationInfo, "NotificationUrl", notificationUrl);
            SetPropertyValue(notificationInfo, "ObjectType", objectType);
            if (operatorUserId != Guid.Empty)
            {
                SetPropertyValue(notificationInfo, "CreatedById", operatorUserId);
                SetPropertyValue(notificationInfo, "ModifiedById", operatorUserId);
            }
            SetPropertyValue(notificationInfo, "CreatedOn", DateTime.Now);
            SetPropertyValue(notificationInfo, "ModifiedOn", DateTime.Now);

            IList recipientList = GetPropertyValue(notificationInfo, "NotificationRecipients") as IList;

            List<Guid> userList = GetUserList(config, variablesValues, operatorUserId);
            if (userList.Count > 0) context.Set(notificationType).Add(notificationInfo);
            foreach (var user in userList)
            {
                var recipientInfo = Activator.CreateInstance(recipientType);
                SetPropertyValue(recipientInfo, "NotificationRecipientId", Guid.NewGuid());
                SetPropertyValue(recipientInfo, "NotificationId", notificationId);
                SetPropertyValue(recipientInfo, "RecipientId", user);
                SetPropertyValue(recipientInfo, "NotificationStatus", "NotSend");
                context.Set(recipientType).Add(recipientInfo);
                recipientList.Add(recipientInfo);
            }
        }

        private static void SetPropertyValue(object obj,string propertyName,object value)
        {
            System.Reflection.PropertyInfo info =  obj.GetType().GetProperty(propertyName);
            if (info == null) return;
            info.SetValue(obj, value, null);
        }

        private static object GetPropertyValue(object obj, string propertyName)
        {
            System.Reflection.PropertyInfo info = obj.GetType().GetProperty(propertyName);
            if (info == null) return null;
            return info.GetValue(obj,null);
        }

        private static List<Guid> GetUserList(NotificationProfile config, Dictionary<string, object> variablesValues,Guid operatorUserId)
        {
            DbContext commonContext = DynamicModelBuilder.CreateDataSource();
            List<Guid> userList = new List<Guid>();
            List<NotificationRecipientAttribute> recipientConfigs = config.NotificationRecipientAttributes.ToList() as List<NotificationRecipientAttribute>;
            MetadataService client = new MetadataService();
            foreach (NotificationRecipientAttribute reipientConfig in recipientConfigs)
            {
                FilterCriteriaHelper helper = new FilterCriteriaHelper(reipientConfig.RecipientEntityId ?? Guid.Empty, variablesValues);
                CriteriaOperator theOperator = helper.GeneratrCriteria(reipientConfig.Criterion);
                var filterEntiy = MetadataProvider.Instance.EntiyMetadata.Where(c => c.EntityId == reipientConfig.RecipientEntityId).First();
                Type filterEntityType = DynamicTypeBuilder.Instance.GetDynamicType(filterEntiy.Name);

                IQueryable query = commonContext.Set(filterEntityType).AsQueryable();
                System.Linq.Expressions.Expression exception = GetExpression(query,theOperator);
                query = query.Provider.CreateQuery(exception);
                IEnumerator iter = query.GetEnumerator();
                EntityAttribute att = filterEntiy.Attributes.Where(c => c.AttributeId == reipientConfig.AttributeId).First();
                while (iter.MoveNext())
                {
                    object userIdValue = GetPropertyValue(iter.Current, att.PhysicalName);
                    if (userIdValue is Guid)
                    {
                        Guid userId = (Guid)GetPropertyValue(iter.Current, att.PhysicalName);
                        if (!userList.Contains(userId) && userId != operatorUserId) userList.Add(userId);
                    }
                }
            }
            if (config.Subscriptions != null)
            {
                foreach (var subscription in config.Subscriptions)
                {
                    if (subscription.UserId != null && subscription.UserId != operatorUserId)
                        if (!userList.Contains((Guid)subscription.UserId)) userList.Add((Guid)subscription.UserId);
                }
            }
            return userList;
        }

        private static System.Linq.Expressions.Expression GetExpression(IQueryable query, CriteriaOperator theOperator)
        {
            var elementType = query.ElementType;
            var converter = new DevExpress.Data.Linq.CriteriaToExpressionConverter();
            ParameterExpression thisExpression = Expression.Parameter(elementType, "");
            Expression predicate =
                Expression.Quote(Expression.Lambda(converter.Convert(thisExpression, theOperator), thisExpression));

            MethodCallExpression methodCallExpression =
                Expression.Call(typeof(Queryable), "Where",
                                new Type[1] { elementType }, new Expression[2]
                                                                       {
                                                                           query.Expression, predicate
                                                                       });
            return methodCallExpression;
        }

        private static BinaryOperator GetKeyOperator(Guid entityId,string primaryKey)
        {
            BinaryOperator bOperator = new BinaryOperator();
            bOperator.OperatorType = BinaryOperatorType.Equal;
            bOperator.LeftOperand = ConstantValue.Parse(primaryKey);
            bOperator.RightOperand = new ConstantValue(entityId);
            return bOperator;
        }
    }
}
