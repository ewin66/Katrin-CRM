using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Workspaces;

namespace Katrin.AppFramework.WinForms.MVC
{
    public class ActionParameters : Dictionary<string, object>
    {
        private string _objectName;
        private Guid _objectId;
        private ViewShowType _viewShowType;
        public ActionParameters(string objectName, Guid objectId, ViewShowType viewShowType)
        {
            _objectName = objectName;
            _objectId = objectId;
            _viewShowType = viewShowType;
        }

        public string ObjectName { get { return this._objectName; } }
        public Guid ObjectId { get { return this._objectId; } }
        public ViewShowType ViewShowType { get { return this._viewShowType; } }
        public T Get<T>(string key)
        {
            var value = this[key];
            if (typeof(T).IsInstanceOfType(value))
                return (T)value;
            TypeConverter c = TypeDescriptor.GetConverter(typeof(T));
            return (T)c.ConvertFrom(value);
        }


    }
}
