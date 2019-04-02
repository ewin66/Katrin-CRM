using System;
using System.Linq;
using System.Reflection;

//idea based on http://www.codeproject.com/KB/cs/dynamicobjectproxy.aspx

namespace SysBits.Reflection
{
	public interface IStaticProxy
	{
		object ProxiedObject { get; }
		Type GetPropertyType(string propertyName);
		void SetProperty(string propertyName, object value);
		object GetProperty(string propertyName);
		bool TrySetProperty(string propertyName, object value);
		bool TryGetProperty(string propertyName, out object result);

		object InvokeMethod(string methodName, params object[] args);
		bool TryInvokeMethod(string methodName, out object result, params object[] args);
	}

	public class ReflectionProxy : IStaticProxy
	{
		protected readonly TypeInfoCache TypeInfoCache;
		protected readonly bool FullAccess;

		public ReflectionProxy(object proxiedObject, bool fullAccess = false, Type forceType = null)
		{
			if (proxiedObject == null) throw new ArgumentNullException("proxiedObject");
			ProxiedObject = proxiedObject;
			if (forceType != null)
			{
				if (!ProxiedObject.GetType().IsSubclassOf(forceType) && ProxiedObject.GetType() != forceType)
					throw new ArgumentException("Forced type should be super class of the object type");
			}
			else
				forceType = ProxiedObject.GetType();
			TypeInfoCache = GlobalTypeInfoCache.GetTypeInfo(forceType);
			FullAccess = fullAccess;
		}

		public static ReflectionProxy FromType(bool fullAccess, Assembly asm, string typeName, params object[] args)
		{
			var asmTypes = asm.GetTypes();
			var type = asmTypes.First(item => item.Name == typeName);

			var typeInfo = GlobalTypeInfoCache.GetTypeInfo(type);

			var argTypes = from a in args
			               select a.GetType();

			var ctor = typeInfo.GetConstructorInfo(argTypes.ToArray(), fullAccess);
			if (ctor == null) return null;
			
			var instance = ctor.Invoke(args);
			return new ReflectionProxy(instance, fullAccess);
		}

		#region IStaticProxy implementation

		public object ProxiedObject { get; private set; }

		public Type GetPropertyType(string propertyName)
		{
			var pie = TypeInfoCache.GetPropertyInfoEx(propertyName, FullAccess);
			if (pie == null)
				throw new ArgumentException("Property " + propertyName + " doesn't exist in type " + TypeInfoCache.Type);
			return pie.Type;
		}

		public virtual void SetProperty(string propertyName, object value)
		{
			var pie = TypeInfoCache.GetPropertyInfoEx(propertyName, FullAccess);
			if (pie == null)
				throw new ArgumentException("Property " + propertyName + " doesn't exist in type " + TypeInfoCache.Type);
			var setter = pie.FastSetter;
			if (setter == null)
			{
				if (FullAccess) setter = pie.Setter;
				if (setter == null)
					throw new ArgumentException("Property " + propertyName + " doesn't have write access in type " + TypeInfoCache.Type);
			}
            if (!pie.Type.IsInstanceOfType(value) && value != null)
				value = Convert.ChangeType(value, pie.Type);

			setter(ProxiedObject, value);
		}

		public virtual object GetProperty(string propertyName)
		{
			var pie = TypeInfoCache.GetPropertyInfoEx(propertyName, FullAccess);
			if (pie == null)
				throw new ArgumentException("Property " + propertyName + " doesn't exist in type " + TypeInfoCache.Type);
			var getter = pie.FastGetter;
			if (getter == null)
			{
				if (FullAccess) getter = pie.Getter;
				if (getter == null)
					throw new ArgumentException("Property " + propertyName + " doesn't have read access in type " + TypeInfoCache.Type);
			}

			return getter(ProxiedObject);
		}

		public virtual bool TrySetProperty(string propertyName, object value)
		{
            try
            {
                var pie = TypeInfoCache.GetPropertyInfoEx(propertyName, FullAccess);
                if (pie == null) return false;
                var setter = pie.FastSetter;
                if (setter == null)
                {
                    if (FullAccess) setter = pie.Setter;
                    if (setter == null) return false;
                }
                if (!pie.Type.IsInstanceOfType(value) && value != null)
                    value = Convert.ChangeType(value, pie.Type);

                setter(ProxiedObject, value);
                return true;
            }
            catch
            {
                return false;
            }
		}

		public virtual bool TryGetProperty(string propertyName, out object result)
		{
			result = null;
			try
			{
				var pie = TypeInfoCache.GetPropertyInfoEx(propertyName, FullAccess);
				if (pie == null) return false;
				var getter = pie.FastGetter;
				if (getter == null)
				{
					if (FullAccess) getter = pie.Getter;
					if (getter == null) return false;
				}

				result = getter(ProxiedObject);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public virtual object InvokeMethod(string methodName, params object[] args)
		{
			var argTypes = new Type[args.Length];
			for (int i = 0; i < args.Length; i++)
				argTypes[i] = args[i].GetType();

			var methodInfo = TypeInfoCache.GetMethodInfo(methodName, argTypes, FullAccess);
			if (methodInfo == null)
				throw new ArgumentException("Method " + methodName + " doesn't exist or inaccessible in type " + TypeInfoCache.Type);

			return methodInfo.Invoke(ProxiedObject, args);
		}

		public virtual bool TryInvokeMethod(string methodName, out object result, params object[] args)
		{
			result = null;
			var argTypes = new Type[args.Length];
			for (int i = 0; i < args.Length; i++)
				argTypes[i] = args[i].GetType();

			var methodInfo = TypeInfoCache.GetMethodInfo(methodName, argTypes, FullAccess);
			if (methodInfo == null) return false;

			result = methodInfo.Invoke(ProxiedObject, args);
			return true;
		}

		#endregion
	}
}
