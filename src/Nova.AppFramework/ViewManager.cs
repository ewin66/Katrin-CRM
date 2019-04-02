using Katrin.AppFramework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework
{
    class ViewManager
    {
        public DetailView CreateDetailView(IObjectSpace objectSpace, Object obj, View sourceView)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            bool isRoot = true;
            lock (this)
            {
                if (sourceView != null)
                {
                    isRoot = (sourceView.ObjectSpace != objectSpace);
                }
                String detailViewId = FindDetailViewId(obj, sourceView);
                return CreateDetailView(objectSpace, detailViewId, isRoot, obj);
            }
        }

        public DetailView CreateDetailView(IObjectSpace objectSpace, String detailViewID, Boolean isRoot, Object obj)
        {
            Guard.ArgumentNotNull(objectSpace, "objectSpace");
            DetailView result = new DetailView();
            return result;
        }

        public String FindDetailViewId(Object obj, View sourceView)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            String result = "";
            Type objectType = obj.GetType();
            result = objectType.Name;
            return result;
        }
    }
}
