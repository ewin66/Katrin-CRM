using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using SysBits.Reflection;

//idea based on http://www.codeproject.com/KB/cs/dynamicobjectproxy.aspx

namespace SysBits.DynamicProxies
{
	public interface IPropertyValidator
	{
		IEnumerable<string> GetValidationProperties(IStaticProxy proxy);
		bool Validate(IStaticProxy proxy, string propertyName, object value, ICollection<ValidationResult> validationResults);
	}

	public class ValidationAttributePropertyValidator : IPropertyValidator
	{
		protected virtual IEnumerable<ValidationAttribute> GetAttributes(MemberInfo propertyInfo) { return propertyInfo.GetCustomAttributes(typeof(ValidationAttribute), true).Cast<ValidationAttribute>(); }

		#region IPropertyValidator interface

		public virtual IEnumerable<string> GetValidationProperties(IStaticProxy proxy)
		{
			if (proxy == null)
				throw new ArgumentNullException("proxy");
			Debug.Assert(proxy.ProxiedObject != null, "Proxy should wrap valid object");
			return proxy.ProxiedObject.GetType().GetProperties().Where(pi => GetAttributes(pi).Any()).Select(pi => pi.Name);
		}

		public bool Validate(IStaticProxy proxy, string propertyName, object value, ICollection<ValidationResult> validationResults)
		{
			Debug.Assert(proxy != null, "Valid proxy should be specified");
			Debug.Assert(proxy.ProxiedObject != null, "Proxy should wrap valid object");
			var info = GlobalTypeInfoCache.GetTypeInfo(proxy.ProxiedObject.GetType()).GetPropertyInfo(propertyName);
			var validationAttributes = GetAttributes(info);
			if (validationAttributes.Count() == 0)
				return true;

			var validationContext = new ValidationContext(proxy.ProxiedObject, null, null);

			var isValid = Validator.TryValidateValue(value, validationContext, validationResults, validationAttributes);

			if (isValid)
			{
				var propertyType = proxy.GetPropertyType(propertyName);
				try
				{
					if (propertyType != value.GetType())
						Convert.ChangeType(value, propertyType);
				}
				catch (Exception)
				{
					validationResults.Add(new ValidationResult("Cannot convert value to type " + propertyType));
					isValid = false;
				}
			}
			return isValid;
		}

		#endregion
	}

	public class CustomPropertyValidator : ValidationAttributePropertyValidator
	{
		#region public nested class

		public class ValidationAttributesCollection
		{
			#region private members

			private readonly Dictionary<string, List<ValidationAttribute>> _customValidationAttributes = new Dictionary<string, List<ValidationAttribute>>();

			#endregion

			#region public methods

			public bool HasAttributes(string propertyName)
			{
				return
					_customValidationAttributes.ContainsKey(propertyName) &&
					_customValidationAttributes[propertyName].Count > 0;
			}

			public void Clear(string propertyName)
			{
				if (_customValidationAttributes.ContainsKey(propertyName))
					_customValidationAttributes.Remove(propertyName);
			}

			public void Clear() { _customValidationAttributes.Clear(); }

			#endregion

			#region public properties

			public List<ValidationAttribute> this[string propertyName]
			{
				get
				{
					List<ValidationAttribute> returnValue;

					if (!_customValidationAttributes.TryGetValue(propertyName, out returnValue))
					{
						returnValue = new List<ValidationAttribute>();
						_customValidationAttributes.Add(propertyName, returnValue);
					}

					return returnValue;
				}

				set
				{
					if (_customValidationAttributes.ContainsKey(propertyName))
						_customValidationAttributes.Add(propertyName, value);
					else
						_customValidationAttributes[propertyName] = value;
				}
			}

			#endregion
		}

		#endregion

		public CustomPropertyValidator() { ValidationAttributes = new ValidationAttributesCollection(); }

		#region protected methods

		protected override IEnumerable<ValidationAttribute> GetAttributes(MemberInfo propertyInfo)
		{
			var returnValue = base.GetAttributes(propertyInfo);

			if (ValidationAttributes.HasAttributes(propertyInfo.Name))
				returnValue = returnValue.Concat(ValidationAttributes[propertyInfo.Name]);

			return returnValue;
		}

		#endregion

		#region public properties

		public ValidationAttributesCollection ValidationAttributes { get; private set; }

		#endregion
	}
}
