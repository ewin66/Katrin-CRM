using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.CompositeUI;

namespace Katrin.Win.Common.Core
{
    public class SingleWorkItemService: ISingleWorkItemService
    {
        private WorkItem _currentWorkItem;

        public void ShowEntityList<T>(WorkItem workItem, string key) where T : WorkItem
        {
            var listController = workItem.Items.Get<T>(key);
            if (listController == null)
            {
                listController = workItem.Items.AddNew<T>(key);
                listController.Run();
            }
            listController.Activate();
            if (listController != _currentWorkItem && _currentWorkItem != null)
                _currentWorkItem.Terminate();
            _currentWorkItem = listController;
        }
    }
}
