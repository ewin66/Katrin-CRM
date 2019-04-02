using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SysBits.Reflection;

//based on http://www.codeproject.com/KB/cs/dynamicobjectproxy.aspx

namespace SysBits.DynamicProxies
{
	public class ValidatingProxy : EditableProxy
	{
		#region protected members

		protected readonly Dictionary<string, Collection<ValidationResult>> ValidationResults = new Dictionary<string, Collection<ValidationResult>>();

		protected IPropertyValidator PropertyValidator { get; private set; }

		#endregion

		#region protected methods

		protected override void SetMember(string propertyName, object value)
		{
			if (ValidateOnChange)
				Validate(propertyName, value);
			base.SetMember(propertyName, value);
		}

		protected bool Validate(string propertyName, object value)
		{
			var validationResults = new Collection<ValidationResult>();
			bool isValid = PropertyValidator.Validate(Proxy, propertyName, value, validationResults);

			if (isValid)
			{
				if (ValidationResults.ContainsKey(propertyName))
					ValidationResults.Remove(propertyName);
			}
			else if (ValidationResults.ContainsKey(propertyName))
				ValidationResults[propertyName] = validationResults;
			else
				ValidationResults.Add(propertyName, validationResults);

			return isValid;
		}

		#endregion

		#region constructor

		public ValidatingProxy(object proxiedObject, IPropertyValidator propertyValidator = null) : base(proxiedObject)
		{
			ValidateOnChange = true;
			SetPropertyValidator(propertyValidator);
		}

		public ValidatingProxy(IStaticProxy proxy, IPropertyValidator propertyValidator = null) : base(proxy)
		{
			ValidateOnChange = true;
			SetPropertyValidator(propertyValidator);
		}

		#endregion

		#region public methods

		public virtual bool Validate(string propertyName) { return Validate(propertyName, GetMember(propertyName)); }

		public virtual bool Validate() { return PropertyValidator.GetValidationProperties(Proxy).Aggregate(true, (isValid, propertyName) => isValid & Validate(propertyName)); }

		public void SetPropertyValidator(IPropertyValidator propertyValidator) { PropertyValidator = propertyValidator ?? new ValidationAttributePropertyValidator(); }

		#endregion

		#region public properties

		public bool ValidateOnChange { get; set; }

		public bool HasErrors { get { return ValidationResults.Count > 0; } }

		#endregion
	}
}
