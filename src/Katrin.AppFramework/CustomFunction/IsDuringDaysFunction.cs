
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;

namespace Katrin.AppFramework.CustomFunction
{
    public class IsDuringDaysFunction : ICustomFunctionOperatorBrowsable
    {
        public const string FunctionName = "IsDuringDays";
        private static readonly IsDuringDaysFunction instance = new IsDuringDaysFunction();

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
            get { return "IsDuringDays"; }
        }

        public bool IsValidOperandCount(int count)
        {
            return count == 2;
        }

        public bool IsValidOperandType(int operandIndex, int operandCount, Type type)
        {
            return type == typeof(DateTime);
        }

        public int MaxOperandCount
        {
            get { return 2; }
        }

        public int MinOperandCount
        {
            get { return 2; }
        }

        #endregion

        #region ICustomFunctionOperator Members

        public object Evaluate(params object[] operands)
        {
            DateTime dt = Convert.ToDateTime(operands[0]);
            int days = 0 - Convert.ToInt32(operands[1]);
            return dt.Date > DateTime.Now.Date.AddDays(days);
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
