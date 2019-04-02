using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using SysBits.Reflection;

//based on http://www.codeproject.com/KB/cs/dynamicobjectproxy.aspx

namespace SysBits.DynamicProxies
{
	public class EditableProxy : NotifyingProxy, IEditableObject
	{
		#region private nested class

		private class BackupState
		{
			public BackupState()
			{
				OriginalValues = new Dictionary<string, object>();
				NewValues = new Dictionary<string, object>();
			}

			public void SetOriginalValue(string propertyName, object value)
			{
				if (!OriginalValues.ContainsKey(propertyName))
					OriginalValues.Add(propertyName, value);
			}

			public void SetNewValue(string propertyName, object value)
			{
				if (OriginalValues.ContainsKey(propertyName) && OriginalValues[propertyName] == value)
					return;

				if (NewValues.ContainsKey(propertyName))
					NewValues[propertyName] = value;
				else
					NewValues.Add(propertyName, value);
			}

			private Dictionary<string, object> OriginalValues { get; set; }
			public Dictionary<string, object> NewValues { get; private set; }
		}

		#endregion

		#region private members

		private BackupState _editBackup;

		#endregion

		#region protected methods

		protected override void SetMember(string propertyName, object value)
		{
			if (IsEditing)
			{
				_editBackup.SetOriginalValue(propertyName, Proxy.GetProperty(propertyName));
				_editBackup.SetNewValue(propertyName, value);
				RaisePropertyChanged(propertyName);
			}
			else
				base.SetMember(propertyName, value);
		}

		protected override object GetMember(string propertyName)
		{
			return IsEditing && _editBackup.NewValues.ContainsKey(propertyName)
			       	? _editBackup.NewValues[propertyName]
			       	: base.GetMember(propertyName);
		}

		#endregion

		#region constructor

		public EditableProxy(object proxiedObject) : base(proxiedObject) { }
		public EditableProxy(IStaticProxy proxy) : base(proxy) { }

		#endregion

		#region public methods

		public override bool TryConvert(ConvertBinder binder, out object result)
		{
			if (binder.Type == typeof(IEditableObject))
			{
				result = this;
				return true;
			}
			return base.TryConvert(binder, out result);
		}

		#endregion

		#region IEditableObject methods

		public void BeginEdit()
		{
			if (!IsEditing)
				_editBackup = new BackupState();
		}

		public void CancelEdit()
		{
			if (IsEditing)
				_editBackup = null;
		}

		public void EndEdit()
		{
			if (IsEditing)
			{
				var editObject = _editBackup;
				_editBackup = null;

				foreach (var item in editObject.NewValues)
					SetMember(item.Key, item.Value);
			}
		}

		#endregion

		#region public properties

		public bool IsEditing { get { return _editBackup != null; } }

		public bool IsChanged { get { return IsEditing && _editBackup.NewValues.Count > 0; } }

		#endregion
	}
}
