using System;
using System.Diagnostics;
using System.Dynamic;
using SysBits.Reflection;

namespace SysBits.DynamicProxies
{
	public class DynamicProxy : DynamicObject
	{
		#region constructor

		public DynamicProxy(IStaticProxy proxy)
		{
			if (proxy == null)
				throw new ArgumentNullException("proxy");
			Proxy = proxy;
		}

		public DynamicProxy(object proxiedObject)
		{
			if (proxiedObject == null)
				throw new ArgumentNullException("proxiedObject");
			Proxy = proxiedObject is IStaticProxy ? (IStaticProxy)proxiedObject : new ReflectionProxy(proxiedObject);
		}

		#endregion

		#region protected members

		protected IStaticProxy Proxy { get; private set; }

		#endregion

		#region protected methods

		protected virtual void SetMember(string propertyName, object value) { Proxy.SetProperty(propertyName, value); }
		protected virtual object GetMember(string propertyName) { return Proxy.GetProperty(propertyName); }

		#endregion

		#region DynamicObject interface

		public override bool TryConvert(ConvertBinder binder, out object result)
		{
			Debug.Assert(Proxy != null);
			if (binder.Type == typeof(IStaticProxy))
			{
				result = Proxy;
				return true;
			}
			if (Proxy.ProxiedObject != null && binder.Type.IsAssignableFrom(Proxy.ProxiedObject.GetType()))
			{
				result = Proxy.ProxiedObject;
				return true;
			}
			return base.TryConvert(binder, out result);
		}

		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			Debug.Assert(Proxy != null);
			try
			{
				result = GetMember(binder.Name);
				return true;
			}
			catch(Exception ex)
			{
				throw new InvalidOperationException("Cannot get member", ex);
			}
		}

		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			Debug.Assert(Proxy != null);
			try
			{
				SetMember(binder.Name, value);
				return true;
			}
			catch(Exception ex)
			{
				throw new InvalidOperationException("Cannot set member", ex);
			}
		}

		public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
		{
			Debug.Assert(Proxy != null);
			return Proxy.TryInvokeMethod(binder.Name, out result, args) || base.TryInvokeMember(binder, args, out result);
		}

		#endregion
	}
}
