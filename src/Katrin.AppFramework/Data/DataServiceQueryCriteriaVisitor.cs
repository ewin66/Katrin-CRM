using Katrin.AppFramework.CustomFunction;
using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;
using ICSharpCode.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.Data
{
    public class DataServiceQueryCriteriaVisitor : ClientCriteriaVisitorBase
    {

        public static CriteriaOperator Prepare(CriteriaOperator criteria)
        {
            return new DataServiceQueryCriteriaVisitor().Process(criteria);
        }

        protected override object Visit(OperandProperty theOperand)
        {
            IFieldProjectStrategy projectionStrategy = ServiceManager.Instance.GetService<IFieldProjectStrategy>();
            theOperand.PropertyName = projectionStrategy.UnProject(theOperand.PropertyName);
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
                case BinaryOperatorType.Equal:
                    string rightString = theOperator.RightOperand.ToString();
                    if (rightString.EndsWith("#") && rightString.StartsWith("#"))
                    {
                        rightString = rightString.TrimStart('#').TrimEnd('#');
                        string leftString = theOperator.LeftOperand.ToString();
                        string filter = leftString + ">= #" + rightString + " 00:00:00# && " + leftString + "<= #" + rightString + " 23:59:59#";
                        return CriteriaOperator.TryParse(filter);
                    }
                    break;

            }
            return base.Visit(theOperator);
        }

        protected override object Visit(BetweenOperator theOperator)
        {
            string endString = theOperator.EndExpression.ToString();
            if (endString.EndsWith("#") && endString.StartsWith("#"))
            {
                endString = endString.TrimStart('#').TrimEnd('#');
                theOperator.EndExpression = new ConstantValue(DateTime.Parse(endString + " 23:59:59"));
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
