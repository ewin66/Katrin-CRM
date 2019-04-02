using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;

namespace Katrin.AppFramework.CustomFunction
{
    public class IsLastMonthFunction : ICustomFunctionOperatorBrowsable
    {
        public const string FunctionName = "IsLastMonth";
        private static readonly IsLastMonthFunction instance = new IsLastMonthFunction();
        public static void Register()
        {
            CriteriaOperator.RegisterCustomFunction(instance);
        }

        public static bool Unregister()
        {
            return CriteriaOperator.UnregisterCustomFunction(instance);
        }

        #region ICustomFunctionOperatorBrowsable Members

        public FunctionCategory Category
        {
            get { return FunctionCategory.DateTime; }
        }

        public string Description
        {
            get { return "IsLastMonth"; }
        }

        public bool IsValidOperandCount(int count)
        {
            return count == 1;
        }

        public bool IsValidOperandType(int operandIndex, int operandCount, Type type)
        {
            return type == typeof(DateTime);
        }

        public int MaxOperandCount
        {
            get { return 1; }
        }

        public int MinOperandCount
        {
            get { return 1; }
        }

        #endregion

        #region ICustomFunctionOperator Members

        public object Evaluate(params object[] operands)
        {
            DateTime dt = Convert.ToDateTime(operands[0]);
            DateTime lastMonth = DateTime.Now.AddMonths(-1);
            return (dt.Date <= Utils.Date.MonthEnd(lastMonth) && dt.Date >= Utils.Date.MonthBegin(lastMonth));
        }

        public string Name
        {
            get { return FunctionName; }
        }

        public Type ResultType(params Type[] operands)
        {
            return typeof(bool);
        }

        #endregion
    }
}
