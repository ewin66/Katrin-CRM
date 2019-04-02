using DevExpress.Data.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Katrin.Win.WcfServerMode
{
    public class CriteriaToQueryExpressionConverter : ICriteriaToExpressionConverter
    {
        public Expression Convert(ParameterExpression thisExpression, DevExpress.Data.Filtering.CriteriaOperator op)
        {
            var converter = new CriteriaToExpressionConverter();
            Expression expression = converter.Convert(thisExpression, op);

            var visitor = new NullPropagationEraseViistor();
            return visitor.Visit(expression);
        }

        class NullPropagationEraseViistor : System.Linq.Expressions.ExpressionVisitor
        {
            private bool _erasingNull;

            protected override Expression VisitUnary(UnaryExpression node)
            {
                if (_erasingNull &&
                    node.NodeType == ExpressionType.Convert &&
                    Nullable.GetUnderlyingType(node.Type) == typeof(bool))
                {
                    return Visit(node.Operand);
                }

                return base.VisitUnary(node);
            }

            protected override Expression VisitBinary(BinaryExpression node)
            {
                if (_erasingNull)
                {
                    Expression left = Visit(node.Left);
                    Expression right = Visit(node.Right);

                    if (left == null)
                    {
                        return right;
                    }

                    if (right == null)
                    {
                        return left;
                    }

                    if (node.NodeType == ExpressionType.NotEqual &&
                        (IsNullConstant(right) || IsNullConstant(left)))
                    {
                        return null;
                    }

                    return Expression.MakeBinary(node.NodeType, left, right);
                }
                return base.VisitBinary(node);
            }

            protected override Expression VisitConditional(ConditionalExpression node)
            {
                Expression expression;
                if (TryRemoveNullPropagation(node, out expression))
                {
                    return expression;
                }

                if (_erasingNull && IsNullCheck(node.Test))
                {
                    return Visit(node.IfFalse);
                }

                return base.VisitConditional(node);
            }

            private bool IsNullCheck(Expression expression)
            {
                if (expression.NodeType != ExpressionType.Equal)
                {
                    return false;
                }

                var binaryExpr = (BinaryExpression)expression;
                return IsNullConstant(binaryExpr.Right);
            }

            private bool TryRemoveNullPropagation(ConditionalExpression node, out Expression condition)
            {
                condition = null;
                if (node.IfTrue.NodeType != ExpressionType.Constant)
                {
                    return false;
                }

                if (node.Test.NodeType != ExpressionType.Equal)
                {
                    return false;
                }

                var test = (BinaryExpression)node.Test;
                var constantExpr = (ConstantExpression)node.IfTrue;

                Expression ifFalse = node.IfFalse;
                if (ifFalse.NodeType == ExpressionType.Convert)
                    ifFalse = ((UnaryExpression)ifFalse).Operand;

                if (ifFalse.NodeType != ExpressionType.Call)
                {
                    return false;
                }

                var memberExpr = (MethodCallExpression)ifFalse;

                _erasingNull = true;
                condition = Visit(memberExpr);
                _erasingNull = false;
                return true;
            }

            private bool IsNullConstant(Expression expression)
            {
                return expression.NodeType == ExpressionType.Constant &&
                       ((ConstantExpression)expression).Value == null;
            }
        }
    }
}
