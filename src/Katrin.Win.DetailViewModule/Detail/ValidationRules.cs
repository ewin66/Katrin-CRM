using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.DXErrorProvider;
using ICSharpCode.Core;

namespace Katrin.Win.DetailViewModule
{
    public class ValidationRules
    {

        static ConditionValidationRule _isNotBlankRule;
        static ConditionValidationRule _isValidationDateRule;
        static ConditionValidationRule _isNotSelectRule;

        public static string GetLocalizedCaption(string name)
        {
            name = "${res:" + name + "}";
            return StringParser.Parse(name);
        }

        public static ConditionValidationRule IsGuidNotBlankRule(string fieldText)
        {
            var rule = new ConditionValidationRule
            {
                ConditionOperator = ConditionOperator.NotAnyOf,
                ErrorText = string.Format(GetLocalizedCaption("ValidateNotBlankMessage"), fieldText),
                ErrorType = ErrorType.Critical
            };
            rule.Values.Add(null);
            rule.Values.Add(Guid.Empty);
            rule.Values.Add(DBNull.Value);
            return rule;
        }

        public static ConditionValidationRule IsNotZeroRule(string fieldText)
        {
            var rule = new ConditionValidationRule
            {
                ConditionOperator = ConditionOperator.NotAnyOf,
                ErrorText = string.Format(GetLocalizedCaption("ValidateNotBlankMessage"), fieldText),
                ErrorType = ErrorType.Critical
            };
            rule.Values.Add(null);
            rule.Values.Add(0);
            rule.Values.Add(DBNull.Value);
            return rule;
        }

        public static ConditionValidationRule IsNotBlankRule(string fieldText)
        {
            return new ConditionValidationRule
            {
                ConditionOperator = ConditionOperator.IsNotBlank,
                ErrorText = string.Format(GetLocalizedCaption("ValidateNotBlankMessage"), fieldText),
                ErrorType = ErrorType.Critical
            };
        }

        public static ConditionValidationRule IsBlankWarningRule(string fieldText)
        {
            return new ConditionValidationRule
            {
                ConditionOperator = ConditionOperator.IsNotBlank,
                ErrorText = string.Format(GetLocalizedCaption("ValidateNotBlankMessage"), fieldText),
                ErrorType = ErrorType.Warning
            };
        }

        public static ConditionValidationRule IsValidationDateRule
        {
            get
            {
                return _isValidationDateRule ??
                       (_isValidationDateRule = new ConditionValidationRule
                       {
                           ConditionOperator = ConditionOperator.NotEquals,
                           ErrorText = GetLocalizedCaption("ValidateDate"),
                           ErrorType = ErrorType.Critical,
                           Value1 = DateTime.MinValue
                       });
            }
        }

        public static ConditionValidationRule IsNotSelectRule
        {
            get
            {
                return _isNotSelectRule ??
                       (_isNotSelectRule = new ConditionValidationRule
                       {
                           ConditionOperator = ConditionOperator.NotEquals,
                           ErrorText = GetLocalizedCaption("ValidateNotBlankMessage"),
                           ErrorType = ErrorType.Critical,
                           Value1 = new Guid(),
                           Value2 = Guid.Empty
                       });
            }
        }

    }
}
