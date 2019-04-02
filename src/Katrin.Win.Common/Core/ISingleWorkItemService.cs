using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.CompositeUI;

namespace Katrin.Win.Common.Core
{
    public interface ISingleWorkItemService
    {
        void ShowEntityList<T>(WorkItem workItem, string key) where T : WorkItem;
    }
}
