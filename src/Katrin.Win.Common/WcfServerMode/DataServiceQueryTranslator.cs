using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Katrin.Win.Common.CustomerFunctions;
using Katrin.Win.Common.CustomerFunctions.Katrin.Win.Common.CustomerFunctions;
using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.Data.Linq;
using DevExpress.Data.WcfLinq.Helpers;

namespace Katrin.Win.WcfServerMode
{

    public class DataServiceQueryTranslator : ExpressionVisitor
    {
        private CriteriaOperator _filter;

        private DataServiceQueryTranslator(CriteriaOperator filter)
        {
            _filter = CriteriaOperator.Clone(filter);
        }

        public static DataServiceQuery Translate(DataServiceQuery source, CriteriaOperator filter)
        {
            var visitor = new DataServiceQueryTranslator(filter);
            Expression reducibleExpression = GetReducibleExpression(source);
            Expression expression = visitor.Visit(reducibleExpression);
            return source.Provider.CreateQuery(expression) as DataServiceQuery;
        }

        public static Expression GetReducibleExpression(DataServiceQuery source)
        {
            if (source.Expression.CanReduce)
                return source.Expression;

            var elementType = source.ElementType;

            ParameterExpression thisExpression = Expression.Parameter(elementType, "");
            Expression predicate = Expression.Lambda(Expression.Constant(true), thisExpression);
            MethodCallExpression methodCallExpression =
                Expression.Call(typeof(Queryable), "Where",
                                new Type[1] { elementType }, new Expression[2]
                                                                       {
                                                                           source.Expression, predicate
                                                                       });
            return methodCallExpression;
        }


        public static DataServiceQuery<TElement> Translate<TElement>(DataServiceQuery<TElement> source, CriteriaOperator filter)
        {
            var visitor = new DataServiceQueryTranslator(filter);
            Expression expression = visitor.Visit(source.Expression);
            return source.Provider.CreateQuery(expression) as DataServiceQuery<TElement>;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.Name == "Where")
            {
                var converter = new CriteriaToQueryExpressionConverter();
                var elementType = node.Method.ReturnType.GetGenericArguments()[0];
                ParameterExpression thisExpression = Expression.Parameter(elementType, "");
                var criteria = ColumnFilterVisitor.Prepare(_filter, elementType);
                Expression filterExpression =
                    Expression.Quote(Expression.Lambda(converter.Convert(thisExpression, criteria), thisExpression));
                return Expression.Call(node.Method, node, filterExpression);
            }
            return base.VisitMethodCall(node);
        }
    }

    public class ColumnFilterVisitor : ClientCriteriaVisitorBase
    {
        private readonly Type _entityType;

        public ColumnFilterVisitor(Type entityType)
        {
            _entityType = entityType;
        }

        public static CriteriaOperator Prepare(CriteriaOperator criteria, Type entityType)
        {
            return new ColumnFilterVisitor(entityType).Process(criteria);
        }

        protected override object Visit(OperandProperty theOperand)
        {
            if (_entityType.GetProperties().All(p => p.Name != theOperand.PropertyName))
            {
                var mappings = GridViewExtension.GetColumnFieldMapping(_entityType.Name);
                if (mappings != null && mappings.Any(m => m.FieldNameMapping == theOperand.PropertyName))
                {
                    var mapping = mappings.First(m => m.FieldNameMapping == theOperand.PropertyName);
                    theOperand.PropertyName = mapping.FiledClrPath;
                }
            }
            return base.Visit(theOperand);
        }

        protected override object Visit(InOperator theOperator)
        {
            var leftOperand = theOperator.LeftOperand;
            GroupOperator group = new GroupOperator();
            group.OperatorType = GroupOperatorType.Or;

            foreach (var operand in theOperator.Operands)
            {
                BinaryOperator criteria = new BinaryOperator();
                criteria.OperatorType = BinaryOperatorType.Equal;
                criteria.LeftOperand = leftOperand;
                criteria.RightOperand = operand;
                group.Operands.Add(criteria);
            }
            return group;
        }


        protected override object Visit(BinaryOperator theOperator)
        {
            switch (theOperator.OperatorType)
            {
                case BinaryOperatorType.Like:
                    var property = (OperandProperty)theOperator.LeftOperand;
                    property = (OperandProperty)Visit(property);
                    FunctionOperator funOperator = new FunctionOperator(FunctionOperatorType.Contains, property, theOperator.RightOperand);
                    return funOperator;

            }
            return base.Visit(theOperator);
        }


        protected override object Visit(FunctionOperator theOperator)
        {
            switch (theOperator.OperatorType)
            {
                case FunctionOperatorType.IsNullOrEmpty:
                    return new BinaryOperator(theOperator.Operands[0], new ConstantValue(null), BinaryOperatorType.Equal);
                case FunctionOperatorType.Custom:
                    var functionName = ((OperandValue)theOperator.Operands[0]).Value.ToString();
                    if (functionName == IsDuringDaysFunction.FunctionName)
                    {
                        var daysOperandValue = ((ConstantValue)theOperator.Operands[2]).Value;
                        int days = 0 - Convert.ToInt32(daysOperandValue);
                        return new BinaryOperator(theOperator.Operands[1],
                            new ConstantValue(DateTime.Now.Date.AddDays(days)), BinaryOperatorType.Greater);
                    }
                    if (functionName == IsLastMonthFunction.FunctionName)
                    {
                        DateTime lastMonth = DateTime.Now.AddMonths(-1);
                        var left = new BinaryOperator(theOperator.Operands[1],
                             new ConstantValue(Utils.Date.MonthBegin(lastMonth)), BinaryOperatorType.GreaterOrEqual);
                        var right = new BinaryOperator(theOperator.Operands[1],
                             new ConstantValue(Utils.Date.MonthEnd(lastMonth)), BinaryOperatorType.LessOrEqual);

                        return CriteriaOperator.And(left, right);
                    }

                    break;
            }

            return base.Visit(theOperator);
        }

    }
}
