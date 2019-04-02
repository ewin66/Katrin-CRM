using System;
using System.Linq.Expressions;
using System.Reflection;

namespace SysBits.Expressions
{
	//based on http://habrahabr.ru/blogs/net/103558/
	public static class PropertyInfoExtensions
	{
		public static Func<object, T> GetValueGetter<T>(this PropertyInfo propertyInfo)
		{
			if (!propertyInfo.CanRead || propertyInfo.GetGetMethod() == null) return null;
			var instance = Expression.Parameter(typeof(Object), "i");
			var castedInstance = Expression.ConvertChecked(instance, propertyInfo.DeclaringType);
			var property = Expression.Property(castedInstance, propertyInfo);
			var convert = Expression.Convert(property, typeof(T));
			var expression = Expression.Lambda(convert, instance);
			return (Func<object, T>)expression.Compile();
		}

		public static Action<object, T> GetValueSetter<T>(this PropertyInfo propertyInfo)
		{
			if (!propertyInfo.CanWrite || propertyInfo.GetSetMethod() == null) return null;
			var instance = Expression.Parameter(typeof(Object), "i");
			var castedInstance = Expression.ConvertChecked(instance, propertyInfo.DeclaringType);
			var argument = Expression.Parameter(typeof(T), "a");
			var setterCall = Expression.Call(
				castedInstance,
				propertyInfo.GetSetMethod(),
				Expression.Convert(argument, propertyInfo.PropertyType));
			return Expression.Lambda<Action<object, T>>(setterCall, instance, argument).Compile();
		}
	}

	//based on http://stackoverflow.com/questions/1272454/generate-dynamic-method-to-set-a-field-of-a-struct-instead-of-using-reflection
	public static class FieldInfoExtensions
	{
		public static Func<object, T> GetValueGetter<T>(this FieldInfo fieldInfo)
		{
			if (!fieldInfo.IsPublic) return null;
			var instance = Expression.Parameter(typeof(Object), "i");
			var castedInstance = Expression.ConvertChecked(instance, fieldInfo.DeclaringType);
			var field = Expression.Field(castedInstance, fieldInfo);
			var convert = Expression.Convert(field, typeof(T));
			var expression = Expression.Lambda(convert, instance);
			return (Func<object, T>)expression.Compile();
		}

		public static Action<object, T> GetValueSetter<T>(this FieldInfo fieldInfo)
		{
			if (!fieldInfo.IsPublic || fieldInfo.IsInitOnly) return null;
			var instance = Expression.Parameter(typeof(Object), "i");
			var castedInstance = Expression.ConvertChecked(instance, fieldInfo.DeclaringType);
			var argument = Expression.Parameter(typeof(T), "a");
			var setter = Expression.Assign(
				Expression.Field(castedInstance, fieldInfo),
				Expression.Convert(argument, fieldInfo.FieldType));
			return Expression.Lambda<Action<object, T>>(setter, instance, argument).Compile();
		}
	}
}
