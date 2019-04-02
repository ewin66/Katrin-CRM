using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Katrin.AppFramework.Data
{
    public class ConvertData
    {
        public static T Convert<T>(object obj)
        {
            var retObj = Activator.CreateInstance(typeof(T));
            PropertyInfo[] propertys =  obj.GetType().GetProperties();
            foreach (var pro in propertys)
            {
                if (typeof(T).GetProperty(pro.Name) != null)
                {
                    typeof(T).GetProperty(pro.Name).SetValue(retObj, pro.GetValue(obj, null), null);
                }
            }
            return (T)retObj;
        }
    }
}
