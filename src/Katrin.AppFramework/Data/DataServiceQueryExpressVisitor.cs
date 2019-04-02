using DevExpress.Data.Filtering;
using DevExpress.Data.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Katrin.AppFramework.Data
{
    public class DataServiceQueryExpressVisitor : ExpressionVisitor
    {
        private CriteriaOperator _filter;

        public DataServiceQueryExpressVisitor(CriteriaOperator filter)
        {
            _filter = CriteriaOperator.Clone(filter);
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.Name == "Where")
            {
                var converter = new CriteriaToExpressionConverter();
                var elementType = node.Method.ReturnType.GetGenericArguments()[0];
                ParameterExpression thisExpression = Expression.Parameter(elementType);
                var criteria = DataServiceQueryCriteriaVisitor.Prepare(_filter);
                if (criteria is FunctionOperator && criteria.ToString().Contains("IsPriorDays"))
                {
                    var priorDays = (FunctionOperator)criteria;
                    BinaryOperator prirOperator = new BinaryOperator();
                    prirOperator.LeftOperand = priorDays.Operands[1];
                    int timeSpan = int.Parse(priorDays.Operands[2].ToString()) * (-1);
                    prirOperator.RightOperand = new ConstantValue(DateTime.Now.AddDays(timeSpan));
                    prirOperator.OperatorType = BinaryOperatorType.Less;
                    criteria = prirOperator;
                }
                else if (criteria is GroupOperator && criteria.ToString().Contains("IsPriorDays"))
                {
                    var groupOperator = (GroupOperator)criteria;
                    var priorDays = (FunctionOperator)groupOperator.Operands[0];
                    BinaryOperator prirOperator = new BinaryOperator();
                    prirOperator.LeftOperand = priorDays.Operands[1];
                    int timeSpan = int.Parse(priorDays.Operands[2].ToString()) * (-1);
                    prirOperator.RightOperand = new ConstantValue(DateTime.Now.AddDays(timeSpan));
                    prirOperator.OperatorType = BinaryOperatorType.Less;
                    criteria = prirOperator;
                }
                var expression = Expression.Lambda(converter.Convert(thisExpression, criteria), thisExpression);
                Expression filterExpression = Expression.Quote(expression);
                return Expression.Call(node.Method, node, filterExpression);
            }
            return base.VisitMethodCall(node);
        }


    }

}
