using System;
using System.ComponentModel;
using System.Dynamic;
using System.Text;
using SysBits.Reflection;

//based on http://www.codeproject.com/KB/cs/dynamicobjectproxy.aspx

namespace SysBits.DynamicProxies
{
	public class DataErrorInfoProxy : ValidatingProxy, IDataErrorInfo
	{
		#region constructor

		public DataErrorInfoProxy(object proxiedObject, IPropertyValidator propertyValidator = null) : base(proxiedObject, propertyValidator) { }
		public DataErrorInfoProxy(IStaticProxy proxy, IPropertyValidator propertyValidator = null) : base(proxy, propertyValidator) { }

		#endregion

		#region public methods

		public override bool TryConvert(ConvertBinder binder, out object result)
		{
			if (binder.Type == typeof(IDataErrorInfo))
			{
				result = this;
				return true;
			}
			return base.TryConvert(binder, out result);
		}

		#endregion

		#region IDataErrorInfo Member

		public string Error
		{
			get
			{
				var returnValue = new StringBuilder();

				foreach (var item in ValidationResults)
					foreach (var validationResult in item.Value)
						returnValue.AppendLine(validationResult.ErrorMessage);

				return returnValue.ToString();
			}
		}

		public string this[string columnName] { get { return ValidationResults.ContainsKey(columnName) ? string.Join(Environment.NewLine, ValidationResults[columnName]) : string.Empty; } }

		#endregion
	}
}
