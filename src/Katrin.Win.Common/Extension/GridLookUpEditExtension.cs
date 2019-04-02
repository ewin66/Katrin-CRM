using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Controls;
using DevExpress.XtraEditors.Repository;

namespace Katrin.Win
{
    public static class GridLookUpEditExtension
    {
        class SearchLookUpEditLoadDataContext
        {
            public MyRepositoryItemGridLookUpEdit RepositoryItem { get; set; }
            public object Result { get; set; }
            public List<object> SelectedObjects { get; set; }
        }


        public static void BindData(this MyRepositoryItemGridLookUpEdit repositoryItem, string entityName, string keyFieldName, List<Guid> selectedIds)
        {
            repositoryItem.View.LoadDefaultLayout(entityName);
            repositoryItem.View.InitColumns(entityName);
            repositoryItem.GridSelection = new GridCheckMarksSelection(repositoryItem.View);

            var query = repositoryItem.View.CreateQuery(entityName,null, null);
            var results = query.ToArrayList();
            var selectedObjects = (from object result in results
                                   let dynamicResult = new SysBits.Reflection.ReflectionProxy(result)
                                   let id = (Guid) dynamicResult.GetProperty(keyFieldName)
                                   where selectedIds.Contains(id)
                                   select result).ToList();

            repositoryItem.DataSource = results;
            repositoryItem.GridSelection.SelectAll(selectedObjects);
        }

        public static void BindDataAsync(this MyRepositoryItemGridLookUpEdit repositoryItem, string entityName, string keyFieldName, List<Guid> selectedIds)
        {
            var worker = new BackgroundWorker();
            var context = new SearchLookUpEditLoadDataContext {RepositoryItem = repositoryItem};

            repositoryItem.View.LoadDefaultLayout(entityName);
            repositoryItem.View.InitColumns(entityName);
            repositoryItem.GridSelection = new GridCheckMarksSelection(repositoryItem.View);

            worker.DoWork += (s, e) =>
            {
                var query = repositoryItem.View.CreateQuery(entityName,null, null);
                var results = query.ToArrayList();
                var selectedObjects = (from object result in results
                                       let dynamicResult = new SysBits.Reflection.ReflectionProxy(result)
                                       let id = (Guid)dynamicResult.GetProperty(keyFieldName)
                                       where selectedIds.Contains(id)
                                       select result).ToList();
                context.Result = results;
                context.SelectedObjects = selectedObjects;
                e.Result = context;
            };
            worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
            worker.RunWorkerAsync();

        }

        static void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var context = (SearchLookUpEditLoadDataContext)e.Result;
            context.RepositoryItem.DataSource = context.Result;
            context.RepositoryItem.GridSelection.SelectAll(context.SelectedObjects);
        }
    }
}
