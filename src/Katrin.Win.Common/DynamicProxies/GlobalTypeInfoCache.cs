using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using SysBits.Expressions;

namespace SysBits.Reflection
{
	public static class GlobalTypeInfoCache<T>
	{
		private static readonly TypeInfoCache _typeInfo = GlobalTypeInfoCache.GetTypeInfo(typeof(T));
		public static TypeInfoCache GetTypeInfo() { return _typeInfo; }
	}

	public static class GlobalTypeInfoCache
	{
		private static readonly Dictionary<Type, TypeInfoCache> _typeInfoMap = new Dictionary<Type, TypeInfoCache>();

		public static TypeInfoCache GetTypeInfo(Type type)
		{
			if (type == null) throw new ArgumentNullException("type");
			TypeInfoCache ti;
			if (!_typeInfoMap.TryGetValue(type, out ti))
				_typeInfoMap.Add(type, ti = new TypeInfoCache(type));
			return ti;
		}
	}

	public class TypeInfoCache
	{
		public class PropertyInfoEx
		{
			internal PropertyInfoEx(PropertyInfo propertyInfo)
			{
				Debug.Assert(propertyInfo != null, "PropertyInfo should be specified");
				PropertyInfo = propertyInfo;
				IsPublic = propertyInfo.GetGetMethod() != null || propertyInfo.GetSetMethod() != null;
			}

			internal PropertyInfoEx(FieldInfo fieldInfo)
			{
				Debug.Assert(fieldInfo != null, "FieldInfo should be specified");
				FieldInfo = fieldInfo;
				IsPublic = !fieldInfo.IsPrivate && fieldInfo.IsPublic;
			}

			public PropertyInfo PropertyInfo { get; private set; }
			public FieldInfo FieldInfo { get; private set; }

			#region FastGetter

			private bool _getterInaccessible;
			private Func<object, object> _getter;

			public Func<object, object> FastGetter
			{
				get
				{
					if (_getter == null && !_getterInaccessible)
					{
						_getter = PropertyInfo != null ? PropertyInfo.GetValueGetter<object>() : FieldInfo.GetValueGetter<object>();
						if (_getter == null) _getterInaccessible = true;
					}
					return _getter;
				}
			}

			#endregion

			#region FastSetter

			private bool _setterInaccessible;
			private Action<object, object> _setter;

			public Action<object, object> FastSetter
			{
				get
				{
					if (_setter == null && !_setterInaccessible)
					{
						_setter = PropertyInfo != null ? PropertyInfo.GetValueSetter<object>() : FieldInfo.GetValueSetter<object>();
						if (_setter == null) _setterInaccessible = true;
					}
					return _setter;
				}
			}

			#endregion

			#region Getter

			public Func<object, object> Getter
			{
				get
				{
					if (PropertyInfo == null || PropertyInfo.CanRead) return TheGetter;
					return null;
				}
			}

			private object TheGetter(object theObject) { return PropertyInfo != null ? PropertyInfo.GetValue(theObject, null) : FieldInfo.GetValue(theObject); }

			#endregion

			#region Setter

			public Action<object, object> Setter
			{
				get
				{
					if (PropertyInfo != null)
					{
						if (PropertyInfo.CanWrite)
							return TheSetter;
					}
					else if (!FieldInfo.IsInitOnly)
						return TheSetter;
					return null;
				}
			}

			public void TheSetter(object theObject, object value)
			{
				if (PropertyInfo != null)
					PropertyInfo.SetValue(theObject, value, null);
				else // if(FieldInfo != null)
					FieldInfo.SetValue(theObject, value);
			}

			#endregion

			public bool IsPublic { get; private set; }

			public Type Type { get { return PropertyInfo != null ? PropertyInfo.PropertyType : FieldInfo.FieldType; } }
		}

		private readonly Dictionary<string, PropertyInfoEx> _propertyInfoMap = new Dictionary<string, PropertyInfoEx>();
		public readonly Type Type;
		public TypeInfoCache(Type type) { Type = type; }

		private const BindingFlags DefaultLookup = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance;

		public PropertyInfoEx GetPropertyInfoEx(string propertyName, bool fullAccess = false)
		{
			PropertyInfoEx pie;
			if (!_propertyInfoMap.TryGetValue(propertyName, out pie))
			{
				PropertyInfo pi = GetPropertyInfo(propertyName, DefaultLookup | BindingFlags.NonPublic);
				if (pi != null)
					_propertyInfoMap.Add(propertyName, pie = new PropertyInfoEx(pi));
				else
				{
					// if property not found - search for field with the same name
					FieldInfo fi = GetFieldInfo(propertyName, DefaultLookup | BindingFlags.NonPublic);
					if (fi != null)
						_propertyInfoMap.Add(propertyName, pie = new PropertyInfoEx(fi));
				}
			}
			if (pie != null && (fullAccess || pie.IsPublic)) return pie;
			return null;
		}

		private PropertyInfo GetPropertyInfo(string propertyName, BindingFlags lookup)
		{
			try
			{
				return Type.GetProperty(propertyName, lookup);
			}
			catch (Exception)
			{
				foreach (var propertyInfo in Type.GetProperties(lookup))
					if (propertyInfo.Name == propertyName)
						return propertyInfo;
			}
			return null;
		}

		private FieldInfo GetFieldInfo(string fieldName, BindingFlags lookup)
		{
			try
			{
				return Type.GetField(fieldName, lookup);
			}
			catch (Exception)
			{
				foreach (var fieldInfo in Type.GetFields(lookup))
					if (fieldInfo.Name == fieldName)
						return fieldInfo;
			}
			return null;
		}

		public MemberInfo GetPropertyInfo(string propertyName)
		{
			PropertyInfoEx pie = GetPropertyInfoEx(propertyName);
			if (pie == null) return null;
			if (pie.PropertyInfo != null) return pie.PropertyInfo;
			return pie.FieldInfo;
		}

		public MethodInfo GetMethodInfo(string methodName, Type[] arguments, bool fullAccess)
		{
			var lookup = DefaultLookup;
			if (fullAccess) lookup |= BindingFlags.NonPublic;
			try
			{
				return Type.GetMethod(methodName, lookup, null, arguments, null);
			}
			catch (Exception)
			{
				int argCount = arguments == null ? 0 : arguments.Length;

				foreach(var info in Type.GetMethods(lookup))
				{
					if (info.Name != methodName) continue;
					var parameters = info.GetParameters();
					if (parameters.Length != argCount) continue;
					bool ok = true;
					for (int i = 0; i < argCount; i++)
						if (parameters[i].ParameterType != arguments[i])
						{
							ok = false;
							break;
						}
					if (ok) return info;
				}
			}
			return null;
		}

		public ConstructorInfo GetConstructorInfo(Type[] arguments, bool fullAccess)
		{
			var lookup = DefaultLookup;
			if(fullAccess)
				lookup |= BindingFlags.NonPublic;
			try
			{
				return Type.GetConstructor(lookup, null, arguments, null);
			}
			catch(Exception)
			{
				int argCount = arguments == null ? 0 : arguments.Length;

				foreach(var info in Type.GetConstructors(lookup))
				{
					var parameters = info.GetParameters();
					if(parameters.Length != argCount)
						continue;
					bool ok = true;
					for(int i = 0; i < argCount; i++)
						if(parameters[i].ParameterType != arguments[i])
						{
							ok = false;
							break;
						}
					if(ok)
						return info;
				}
			}
			return null;
		}
	}
}
