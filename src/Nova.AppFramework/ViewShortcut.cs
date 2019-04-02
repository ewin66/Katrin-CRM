using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using Katrin.AppFramework.Utils;

namespace Katrin.AppFramework
{
    public class ObjectKeyHelper
    {
        public const string InvalidObjectKey = "";
        protected virtual string Encode(string str) { return str; }
        protected virtual string Decode(string str) { return str; }
        public string SerializeObjectKey(object objectKey)
        {
            MemoryStream stream = new MemoryStream();
            XmlSerializer serializer = new XmlSerializer(objectKey.GetType());
            serializer.Serialize(stream, objectKey);
            string result = Encoding.UTF8.GetString(stream.GetBuffer());
            int indexOfZero = result.IndexOf('\0');
            if (indexOfZero >= 0)
            {
                result = result.Remove(indexOfZero);
            }
            return Encode(result);
        }
        public object DeserializeObjectKey(string objectKey, Type objectType)
        {
            if (objectKey == InvalidObjectKey)
            {
                return null;
            }
            XmlSerializer serializer = new XmlSerializer(objectType);
            return serializer.Deserialize(new StringReader(Decode(objectKey)));
        }
        private static ObjectKeyHelper instance;
        public static void SetIntance(ObjectKeyHelper newInstance)
        {
            instance = newInstance;
        }
        public static ObjectKeyHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjectKeyHelper();
                }
                return instance;
            }
        }
    }

    public class ViewShortcut : LightDictionary<String, String>
    {
        protected override String GetValueTypeDefault()
        {
            return "";
        }
        public const String scrollXYSeparator = "_";
        public ViewShortcut()
        {
            this[ViewIdParamName] = "";
            this[ObjectKeyParamName] = ObjectKeyHelper.InvalidObjectKey;
            this[ScrollPositionParamName] = "";
        }
        public ViewShortcut(String viewId, Object objectKey)
            : this(null, objectKey, viewId)
        {
        }
        public ViewShortcut(Type objectClass, Object objectKey, String viewId)
            : this()
        {
            this.ObjectClassName = (objectClass != null) ? objectClass.FullName : "";
            if (objectKey != null)
            {
                //if (objectKey.GetType() == typeof(DevExpress.Xpo.Helpers.IdList))
                //{
                //    this.ObjectKey = ObjectKeyHelper.Instance.SerializeObjectKey(objectKey);
                //}
                //else
                {
                    this.ObjectKey = objectKey.ToString();
                }
            }
            if (viewId != null)
            {
                this.ViewId = viewId;
            }
        }
        public ViewShortcut(Type objectClass, Object objectKey, String viewId, Point scrollPosition)
            : this(objectClass, objectKey, viewId)
        {
            ScrollPosition = scrollPosition;
        }
        public Type ObjectClass
        {
            get
            {
                return null;
                //return ReflectionHelper.FindType(ObjectClassName);
            }
        }

        public String ObjectKey
        {
            get { return this[ObjectKeyParamName]; }
            set { this[ObjectKeyParamName] = value; }
        }
        public String ViewId
        {
            get { return this[ViewIdParamName]; }
            set { this[ViewIdParamName] = value; }
        }
        public String ObjectClassName
        {
            get { return this[ObjectClassNameParamName]; }
            set { this[ObjectClassNameParamName] = value; }
        }
        public Point ScrollPosition
        {
            get { return ParseScrollPosition(this[ScrollPositionParamName]); }
            set { this[ScrollPositionParamName] = GetScrollPosition(value); }
        }
        private String GetScrollPosition(Point scrollPosition)
        {
            if (scrollPosition.IsEmpty)
            {
                return string.Empty;
            }
            return scrollPosition.X.ToString() + scrollXYSeparator + scrollPosition.Y.ToString();
        }
        private Point ParseScrollPosition(String scrollPosition)
        {
            string[] items = scrollPosition.Split(scrollXYSeparator.ToCharArray());
            int x, y;
            if (items.Length != 2 || !int.TryParse(items[0], out x) || !int.TryParse(items[1], out y))
            {
                return new Point(0, 0);
            }
            return new Point(x, y);
        }
        public const String ViewIdParamName = "ViewID";
        public const String ObjectClassNameParamName = "ObjectClassName";
        public const String ObjectKeyParamName = "ObjectKey";
        public const String TemporaryObjectKeyParamName = "TemporaryObjectKey";
        public const String ScrollPositionParamName = "ScrollPosition";
        public const String IsNewObject = "NewObject";
        public override String ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                if (result.Length > 0)
                {
                    result.Append('&');
                }
                result.Append(GetKey(i));
                result.Append('=');
                result.Append(this[i]);
            }
            return result.ToString();
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override Boolean Equals(Object obj)
        {
            return Equals(obj, EqualsDefaultIgnoredParameters);
        }
        public static List<String> EqualsDefaultIgnoredParameters = new List<String>(new String[] { ScrollPositionParamName });
        public Boolean Equals(Object obj, IList<String> ignoredParamNames)
        {
            if (base.Equals(obj))
            {
                return true;
            }
            ViewShortcut shortcut = obj as ViewShortcut;
            if (shortcut == null)
            {
                return false;
            }
            if ((shortcut.ObjectClass == this.ObjectClass)
                    && (shortcut.ObjectKey == this.ObjectKey)
                    && (shortcut.ViewId == this.ViewId))
            {
                int maxCount = (Count > shortcut.Count) ? Count : shortcut.Count;
                for (int i = 0; i < maxCount; i++)
                {
                    if (i < shortcut.Count)
                    {
                        if (shortcut[i] != this[shortcut.GetKey(i)] && !ignoredParamNames.Contains(shortcut.GetKey(i)))
                        {
                            return false;
                        }
                    }
                    if (i < Count)
                    {
                        if (this[i] != shortcut[this.GetKey(i)] && !ignoredParamNames.Contains(this.GetKey(i)))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }
        public Boolean HasViewParameters
        {
            get
            {
                return !string.IsNullOrEmpty(ObjectClassName) || !string.IsNullOrEmpty(ViewId);
            }
        }
        public static Boolean operator ==(ViewShortcut a, ViewShortcut b)
        {
            if ((object)a != null)
            {
                return a.Equals(b);
            }
            else
            {
                if ((object)b != null)
                {
                    return b.Equals(a);
                }
                else
                {
                    return true;
                }
            }
        }
        public static Boolean operator !=(ViewShortcut a, ViewShortcut b)
        {
            return !(a == b);
        }
        public static readonly ViewShortcut Empty = new ViewShortcut(null, ObjectKeyHelper.InvalidObjectKey, "");
    }
}
