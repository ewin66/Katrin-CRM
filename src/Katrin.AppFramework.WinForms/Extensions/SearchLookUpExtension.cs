using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.MetadataServiceReference;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Katrin.AppFramework.WinForms.Grid;
using Katrin.Win.Common.Controls;
using System.ComponentModel;
using System.Collections;
using DevExpress.Data.Filtering;
using DevExpress.XtraEditors.Repository;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.Workspaces;
using Katrin.AppFramework.WinForms.Controls;
using System.Windows.Forms;
using DevExpress.XtraEditors.Popup;
namespace Katrin.AppFramework.WinForms.Extensions
{
    public static class SearchLookUpExtension
    {
        #region SearchLookUp

        public static void ReLoadData(this SearchLookUpEdit searchLookUpEdit, CriteriaOperator commonFilter, string objectName)
        {
            searchLookUpEdit.Properties.BindDataAsync(commonFilter, objectName);
        }

        class SearchLookUpEditLoadDataContext
        {
            public RepositoryItemSearchLookUpEdit RepositoryItem { get; set; }
            public object Result { get; set; }
        }

        public static void BindDataAsync(this RepositoryItemSearchLookUpEdit repositoryItem, CriteriaOperator commonFilter, string objectName)
        {
            var worker = new BackgroundWorker();
            repositoryItem.View.InitWithDefaultLayout(objectName);
            var context = new SearchLookUpEditLoadDataContext { RepositoryItem = repositoryItem };
            worker.DoWork += (s, e) =>
            {
                var results = ListData(objectName, commonFilter);
                context.Result = results;
                e.Result = context;
            };
            worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
            worker.RunWorkerAsync();

        }


        static void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var context = (SearchLookUpEditLoadDataContext)e.Result;
            context.RepositoryItem.DataSource = context.Result;
        }


        public static void Bind(this SearchLookUpEdit searchLookUpEdit, Entity entity)
        {
            searchLookUpEdit.Bind(entity, null);
        }
        public static void Bind(this SearchLookUpEdit searchLookUpEdit, Entity entity,CriteriaOperator filter)
        {
            if (entity == null) return;
            if (searchLookUpEdit.DataBindings.Count == 0) return;

            var binding = searchLookUpEdit.DataBindings[0];

            string attributeName = binding.BindingMemberInfo.BindingMember;

            var attribute = entity.Attributes.FirstOrDefault(a => a.PhysicalName.Equals(attributeName));
            if (attribute == null)
            {
                throw new Exception("Attribute Not found:entity =" + entity.Name + " attribute = " + attributeName);
            }
            var lookupValue = attribute.AttributeLookupValues.First();
            var lookupValueEntity = lookupValue.Entity;

            searchLookUpEdit.Properties.BeginInit();

            var entityName = lookupValueEntity.PhysicalName;
            var displayAttribute =
                lookupValueEntity.Attributes.First(a => a.AttributeId == lookupValue.DisplayEntityAttributeId);
            searchLookUpEdit.Properties.DisplayMember = displayAttribute.PhysicalName;

            var primaryKeyAttribute =
                lookupValueEntity.Attributes.Single(a => a.IsPKAttribute.HasValue && a.IsPKAttribute.Value);
            searchLookUpEdit.Properties.ValueMember = primaryKeyAttribute.PhysicalName;
            searchLookUpEdit.Properties.NullText = string.Empty;
            searchLookUpEdit.Properties.AllowNullInput = DefaultBoolean.True;
            searchLookUpEdit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            searchLookUpEdit.Properties.ShowFooter = true;
            
            searchLookUpEdit.Popup += (sender, e) =>
                {
                    PopupSearchLookUpEditForm popup = (PopupSearchLookUpEditForm)(searchLookUpEdit as DevExpress.Utils.Win.IPopupControl).PopupWindow;
                    popup.CloseButton.Width = 0;
                    popup.CloseButton.Height = 0;
                    popup.CloseButton.Visible = false;
                    popup.CloseButton.VisibleChanged += (o, ex) =>
                        {
                            popup.CloseButton.Visible = false;
                        };
                };
           
            searchLookUpEdit.Properties.View.InitWithDefaultLayout(entityName);

            ODataListSource source = new ODataListSource(entityName, filter, null);
            source.AsyncRefreshDataSource();
            searchLookUpEdit.Properties.DataSource = source;
            searchLookUpEdit.Properties.EndInit();
        }

       

        public static IList ListData(string entityName)
        {
            return ListData(entityName, null);
        }

        public static IList ListData(string entityName, CriteriaOperator criteria)
        {
            var projections = GridViewExtension.GetColumnProjections(entityName);
            var fetchColumns = projections.Select(p => string.Format("{0} AS {1}", p.QueryExpression, p.Projection)).ToArray();
            var selector = string.Format("new({0})", string.Join(",", fetchColumns));
            IObjectSpace objectSpace = new ODataObjectSpace();
            return objectSpace.GetObjectQuery(entityName, selector, criteria).ToList();
        }

        public static void AddDetailButton(this SearchLookUpEdit edit, string entityName)
        {
            edit.Properties.Buttons.Add(new EditorButton());
            edit.ButtonClick += (sender, e) =>
            {
                if (edit.EditValue == null
                    || e.Button.Kind != ButtonPredefines.Ellipsis
                    || edit.EditValue == DBNull.Value)
                    return;
                var entityId = (Guid)edit.EditValue;

                var parameters = new ActionParameters(entityName, entityId, ViewShowType.Show){
                    {"WorkingMode",EntityDetailWorkingMode.View}
                };

                App.Instance.Invoke(entityName, "Detail", parameters);
            };
        }


        #endregion

        public static void BindDataAsync(this MyRepositoryItemGridLookUpEdit repositoryItem, string entityName, string keyFieldName, List<Guid> selectedIds)
        {
            var worker = new BackgroundWorker();
            repositoryItem.View.InitWithDefaultLayout(entityName);
            repositoryItem.GridSelection = new GridCheckMarksSelection(repositoryItem.View);
            var context = new MySearchLookUpEditLoadDataContext { RepositoryItem = repositoryItem };
            worker.DoWork += (s, e) =>
            {
                var results = ListData(entityName);
                var selectedObjects = (from object result in results
                                       let id = (Guid)result.GetType().GetProperty(keyFieldName).GetValue(result, null)
                                       where selectedIds.Contains(id)
                                       select result).ToList();
                context.Result = results;
                context.SelectedObjects = selectedObjects;
                e.Result = context;
            };
            worker.RunWorkerCompleted += MyWorkerRunWorkerCompleted;
            worker.RunWorkerAsync();

        }

        static void MyWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var context = (MySearchLookUpEditLoadDataContext)e.Result;
            context.RepositoryItem.DataSource = context.Result;
            context.RepositoryItem.GridSelection.SelectAll(context.SelectedObjects);
        }

        class MySearchLookUpEditLoadDataContext
        {
            public MyRepositoryItemGridLookUpEdit RepositoryItem { get; set; }
            public object Result { get; set; }
            public List<object> SelectedObjects { get; set; }
        }

    }
}
