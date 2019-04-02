using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.Services.Client;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Katrin.Win.Common;
using Katrin.Win.Common.Controls;
using Katrin.Win.Common.Properties;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using DevExpress.Utils;
using Katrin.Win.Common.MetadataServiceReference;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraWaitForm;
using Microsoft.Data.Edm;
using Katrin.Win.Common.Core;
using System.Linq.Expressions;
using DevExpress.Data.Filtering;
using System.Globalization;

namespace Katrin.Win
{
    public class ColumnFieldMapping
    {
        public string FieldName { get; set; }
        public string FieldNameMapping { get; set; }
        public string Expression { get; set; }
        public string FiledClrPath { get; set; }
    }

    public static class GridViewExtension
    {
        private static string GetDefaultLayout(string entityName,ref string detailLayout)
        {
            var entityMetadata = MetadataProvider.Instance.EntiyMetadata.Single(e => e.PhysicalName == entityName);
            var metadataService = MetadataProvider.CreateServiceClient();
            var savedQueries = metadataService.GetSavedQuery(entityMetadata.EntityId);

            var defaultQuery = savedQueries.FirstOrDefault(q => q.QueryType == 0 && q.IsDefault);
            if (defaultQuery == null) defaultQuery = savedQueries.FirstOrDefault();
            if (defaultQuery == null)
            {
                throw new Exception("This is no default list view layout for " + entityName);
            }
            var detailQuery = savedQueries.FirstOrDefault(q => q.QueryParentId == defaultQuery.SavedQueryId);
            if(detailQuery != null) detailLayout = detailQuery.LayoutXml;
            return defaultQuery.LayoutXml;
        }

        public static void LoadDefaultLayout(this ColumnView view, string entityName)
        {
            string detailLayout = string.Empty;
            var defaultLayoutXml = GetDefaultLayout(entityName, ref detailLayout);
            view.RestoreLayoutFromString(defaultLayoutXml);
            LoadDetailLayout(view, detailLayout);
            var columnFieldMappings = GetColumnFieldMapping(entityName);
            foreach (GridColumn column in view.Columns)
            {
                var filedName = column.FieldName;
                var mapping = columnFieldMappings.FirstOrDefault(m => m.FieldName == filedName);
                if (mapping != null) column.FieldName = mapping.FieldNameMapping;
            }
        }

        public static void LoadDetailLayout(ColumnView mainView, string detailLayout)
        {
            if (string.IsNullOrEmpty(detailLayout)) return;
            if (!(mainView is GridView)) return;
            GridView mainGridView = mainView as GridView;
            if (string.IsNullOrEmpty(mainGridView.ChildGridLevelName)) return;
            GridView detailView = new GridView(mainGridView.GridControl);
            DevExpress.XtraGrid.GridLevelNode gridLevelNode = new DevExpress.XtraGrid.GridLevelNode();
            gridLevelNode.LevelTemplate = detailView;
            gridLevelNode.RelationName = mainGridView.ChildGridLevelName;
            mainGridView.GridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] { gridLevelNode });
            detailView.RestoreLayoutFromString(detailLayout);
            string detailEntityName = mainGridView.ChildGridLevelName.TrimEnd('s');
            var columnFieldMappings = GetColumnFieldMapping(detailEntityName);
            foreach (GridColumn column in detailView.Columns)
            {
                var filedName = column.FieldName;
                var mapping = columnFieldMappings.FirstOrDefault(m => m.FieldName == filedName);
                if (mapping != null) column.FieldName = mapping.FieldNameMapping;
            }
            detailView.InitColumns(detailEntityName);
        }

        public static void InitColumns(this ColumnView view, string entityName)
        {
            var entityMetaSet = MetadataProvider.Instance.EntiyMetadata.First(e => e.PhysicalName == entityName);

            var columnFieldMappings = GetColumnFieldMapping(entityName);

            foreach (GridColumn column in view.Columns)
            {
                var fieldName = column.FieldName;
                var mapping = columnFieldMappings.FirstOrDefault(m => m.FieldNameMapping == fieldName);
                if (mapping != null) fieldName = mapping.FieldName;

                var isComplexField = IsComplexField(fieldName);
                if (isComplexField)
                {
                    LocalizeRelatedField(fieldName, column, entityMetaSet);
                    continue;
                }

                var columnMetadata = entityMetaSet.Attributes.FirstOrDefault(a => a.PhysicalName == fieldName);

                if (columnMetadata != null && columnMetadata.OptionSetId != null)
                {
                    var lookUpEdit = new RepositoryItemLookUpEdit();
                    lookUpEdit.BindPickList(entityMetaSet, fieldName);
                    column.ColumnEdit = lookUpEdit;
                }
                else if (columnMetadata !=null && columnMetadata.LogicalName == "MultipleLineText")
                {
                    var memoEdit = new RepositoryItemMemoEdit();
                    column.ColumnEdit = memoEdit;
                }
                var localizedLabel = GetLocalizedLabel(entityMetaSet, fieldName) ??
                                     GetLocalizedLabel(entityMetaSet, column.Caption);
                if (!string.IsNullOrEmpty(localizedLabel)) column.Caption = localizedLabel;
            }
        }

        private static string GetLocalizedLabel(Entity entityMetaSet, string fieldName)
        {
            var culture = CultureManager.CurrentCulture;
            int langId = culture.LCID;
            var attribute = entityMetaSet.Attributes.FirstOrDefault(a => a.PhysicalName == fieldName);
            if (attribute != null)
            {
                var label = MetadataProvider.Instance.LocalizedLabels.FirstOrDefault(l => l.ObjectId == attribute.AttributeId && l.LanguageId == langId);
                if (label != null) return label.Label;
            }
            return null;
        }

        private static bool IsComplexField(string fieldName)
        {
            var fieldSegments = fieldName.Split('.');
            return fieldSegments.Length == 2;
        }

        private static void LocalizeRelatedField(string fieldName, GridColumn column, Entity entity)
        {
            var fieldSegments = fieldName.Split('.');
            if (fieldSegments.Length == 2)
            {
                var mainPropertyName = fieldSegments[0];
                var subPropertyName = fieldSegments[1];
                var mainLocalizedLabel = GetLocalizedLabel(entity, mainPropertyName + "Id");

                var entityType = DynamicDataServiceContext.GetTypeDefinition(entity.PhysicalName);
                var propertyType =
                    entityType.NavigationProperties().Single(p => p.Name == mainPropertyName).ToEntityType();

                var subPropertyEntity =
                    MetadataProvider.Instance.EntiyMetadata.First(e => e.PhysicalName == propertyType.Name);
                var subLocalizedLabel = GetLocalizedLabel(subPropertyEntity, subPropertyName);
                var columnMetadata = subPropertyEntity.Attributes.FirstOrDefault(a => a.PhysicalName == subPropertyName);
                column.Caption = string.Format(Resources.ColumnCaptionFormat, mainLocalizedLabel??string.Empty, subLocalizedLabel);
                if (columnMetadata != null && columnMetadata.OptionSetId != null)
                {
                    var lookUpEdit = new RepositoryItemLookUpEdit();
                    lookUpEdit.BindPickList(subPropertyEntity, subPropertyName);
                    column.ColumnEdit = lookUpEdit;
                }
                else if (columnMetadata != null && columnMetadata.LogicalName == "MultipleLineText")
                {
                    var memoEdit = new RepositoryItemMemoEdit();
                    column.ColumnEdit = memoEdit;
                }

            }
        }

        private static void SetDataSource(ColumnView view, object dataSource)
        {
            if (view.GridControl == null) return;
            var bindingSource = view.GridControl.DataSource as BindingSource;
            view.GridControl.BeginUpdate();
            if (bindingSource != null)
            {
                bindingSource.DataSource = dataSource;
            }
            else
            {
                view.GridControl.DataSource = dataSource;
            }
            view.GridControl.EndUpdate();
        }

        private static void ClearDataSource(this ColumnView view,BindingSource bindingSource, string entityName)
        {
            CancelPeddingBackgroundWorker(view, entityName);
            bindingSource.Clear();
            view.RefreshData();
        }

        private static Dictionary<int,string[]> _cachedEntityProperty =new Dictionary<int, string[]>();
        private static Dictionary<string, List<ColumnFieldMapping>> _cachedColumnFieldMapping = new Dictionary<string, List<ColumnFieldMapping>>();

        public static List<ColumnFieldMapping> GetColumnFieldMapping(string entityName)
        {
            if (!_cachedColumnFieldMapping.Keys.Contains(entityName))
            {
                GridView gridView = new GridView();
                string detailLayout = string.Empty;
                var defaultLayoutXml = GetDefaultLayout(entityName, ref detailLayout);
                gridView.RestoreLayoutFromString(defaultLayoutXml);
                var columnFieldMapping = new List<ColumnFieldMapping>();
                Type entityType = DynamicTypeBuilder.Instance.GetDynamicType(entityName);
                gridView.Columns.Cast<GridColumn>().ToList()
                    .ForEach(column =>
                    {
                        var filedName = column.FieldName;
                        if (filedName != "" && filedName != GridCheckMarksSelection.CheckMarkFieldName)
                        {
                            if (!(!filedName.Contains(".") && entityType != null && entityType.GetProperty(filedName) == null))
                            {
                                var mapping = GetMappedFieldName(entityName, filedName);
                                columnFieldMapping.Add(mapping);
                            }
                        }
                    });
                if (!string.IsNullOrEmpty(gridView.ChildGridLevelName))
                {
                    var mapping = GetMappedFieldName(entityName, gridView.ChildGridLevelName);
                    columnFieldMapping.Add(mapping);
                }
                _cachedColumnFieldMapping[entityName] = columnFieldMapping;
                gridView.Dispose();
                gridView = null;
            }
            return _cachedColumnFieldMapping[entityName];
        }

        public static DataServiceQuery CreateQuery(this ColumnView view, string entityName, CriteriaOperator commonFilter, Dictionary<string, string> properties)
        {
            return CreateQuery(entityName, commonFilter, properties);
        }

        public static DataServiceQuery CreateQuery(string entityName, CriteriaOperator commonFilter, Dictionary<string, string> properties)
        {
            var fetchColumns = GetColumnFieldMapping(entityName).ToDictionary(kvp => kvp.FieldNameMapping, kvp => kvp.Expression);
            if (properties != null)
            {
                fetchColumns = properties.Concat(fetchColumns).ToDictionary(e => e.Key, e => e.Value);
            }

            var query = new DynamicDataServiceContext().CreateObjectQuery(entityName, commonFilter, fetchColumns);
            return query;
        }

        private static Dictionary<string, BackgroundWorker> _cachedBackgroundWorker = new Dictionary<string, BackgroundWorker>();

        public static void BindDataAsync(this ColumnView view, IActionContext actionContext, string entityName, Action completedCallback, CriteriaOperator commonFilter, Dictionary<string, string> properties)
        {
            ClearDataSource(view, actionContext.BindingSource, entityName);

            var cacheKey = view.GetHashCode() + entityName;

            var worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            _cachedBackgroundWorker[cacheKey] = worker;
            var result = new LoadDataAsynResult { Context = actionContext, Action = completedCallback };
            var query = CreateQuery(entityName, commonFilter, properties);
            worker.DoWork += (s, e) =>
            {
                if (e.Cancel) return;
                result.Result = query.ToList();
                e.Result = result;
            };
            worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        private static string CancelPeddingBackgroundWorker(ColumnView view, string entityName)
        {
            var cacheKey = view.GetHashCode() + entityName;
            if (_cachedBackgroundWorker.ContainsKey(cacheKey))
            {
                var backgroundWorker = _cachedBackgroundWorker[cacheKey];
                if (!backgroundWorker.CancellationPending)
                {
                    backgroundWorker.RunWorkerCompleted -= WorkerRunWorkerCompleted;
                    backgroundWorker.CancelAsync();
                }
                _cachedBackgroundWorker.Remove(cacheKey);
                backgroundWorker.Dispose();
            }
            return cacheKey;
        }


        static void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) return;
            var asynResult = (LoadDataAsynResult)e.Result;
            asynResult.Context.BindingSource.DataSource = asynResult.Result;
            if (asynResult.Action != null) asynResult.Action();
        }

        private static bool IsLookUpField(string entityName, string fieldName)
        {
            var entity = MetadataProvider.Instance.EntiyMetadata.First(e => e.PhysicalName == entityName);
            var attribute = entity.Attributes.FirstOrDefault(a => a.PhysicalName == fieldName);
            if (attribute != null && attribute.AttributeLookupValues.Any())
            {
                return true;
            }
            return false;
        }

        private static ColumnFieldMapping GetMappedFieldName(string entityName, string fieldName)
        {
            var entity = MetadataProvider.Instance.EntiyMetadata.First(e => e.PhysicalName == entityName);
            var attribute = entity.Attributes.FirstOrDefault(a => a.PhysicalName == fieldName);
            if (attribute != null && attribute.AttributeLookupValues.Any())
            {
                var lookupValue = attribute.AttributeLookupValues.First();
                var lookupValueEntity = lookupValue.Entity;
                string displayMemberName =
                    lookupValueEntity.Attributes.First(a => a.AttributeId == lookupValue.DisplayEntityAttributeId).
                        PhysicalName;
                var propertyName = fieldName.Substring(0, fieldName.Length - 2);

                var key = propertyName + displayMemberName;
                var clrPath = string.Format("{0}.{1}", propertyName, displayMemberName);
                var expression = string.Format("{0} == null?null:{1}", propertyName, clrPath);
                return new ColumnFieldMapping
                {
                    FieldName = fieldName,
                    FieldNameMapping = key,
                    FiledClrPath = clrPath,
                    Expression = expression
                };
            }

            var filedNameSegments = fieldName.Split('.');
            if (filedNameSegments.Length == 2)
            {
                var key = fieldName.Replace(".", "_");
                var clrPath = string.Format("{0}.{1}", filedNameSegments[0], filedNameSegments[1]);
                var expression = string.Format("{0} == null?null:{1}", filedNameSegments[0], clrPath);
                return new ColumnFieldMapping
                {
                    FieldName = fieldName,
                    FieldNameMapping = key,
                    FiledClrPath = clrPath,
                    Expression = expression
                };
            }
            return new ColumnFieldMapping
            {
                FieldName = fieldName,
                FiledClrPath = fieldName,
                FieldNameMapping = fieldName,
                Expression = fieldName
            };
        }

        class LoadDataAsynResult
        {
            public IActionContext Context { get; set; }
            public Action Action { get; set; }
            public object Result { get; set; }
        }
    }
}
