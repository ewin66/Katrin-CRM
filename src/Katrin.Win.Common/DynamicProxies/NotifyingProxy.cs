using System.ComponentModel;
using System.Dynamic;
using SysBits.Reflection;

//based on http://www.codeproject.com/KB/cs/dynamicobjectproxy.aspx

namespace SysBits.DynamicProxies
{
	public class NotifyingProxy : DynamicProxy, INotifyPropertyChanged
	{
		#region protected methods

		protected override void SetMember(string propertyName, object value)
		{
			base.SetMember(propertyName, value);
			RaisePropertyChanged(propertyName);
		}

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		protected virtual void RaisePropertyChanged(string propertyName) { OnPropertyChanged(propertyName); }

		#endregion

		public override bool TryConvert(ConvertBinder binder, out object result)
		{
			if (binder.Type == typeof(INotifyPropertyChanged))
			{
				result = this;
				return true;
			}

			return base.TryConvert(binder, out result);
		}

		#region constructor

		public NotifyingProxy(object proxiedObject) : base(proxiedObject) { }
		public NotifyingProxy(IStaticProxy proxy) : base(proxy) { }

		#endregion

		#region INotifyPropertyChanged Member

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion
	}
}
