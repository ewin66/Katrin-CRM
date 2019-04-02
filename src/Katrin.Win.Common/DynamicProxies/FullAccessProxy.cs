using System;
using System.Reflection;
using SysBits.Reflection;

namespace SysBits.DynamicProxies
{
	internal class FullAccessProxy : DynamicProxy
	{
		public FullAccessProxy(object o, Type forceType = null) : base(new ReflectionProxy(o, true, forceType)) { }

		private FullAccessProxy(IStaticProxy proxy) : base(proxy) { }

		/// <summary>
		/// 	Create an instance via the constructor matching the args
		/// </summary>
		public static dynamic FromType(Assembly asm, string typeName, params object[] args)
		{
			var proxy = ReflectionProxy.FromType(true, asm, typeName, args);
			if (proxy == null) return null;
			return new FullAccessProxy(proxy);
		}
	}
}
