using Katrin.AppFramework.Metadata;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.MetadataServiceReference;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Data.Edm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.Grid
{
    public static class GridViewExtension
    {
        public static void RestoreLayoutFromString(this ColumnView serializer, string layout)
        {
            using (var stream = new MemoryStream())
            {
                if (string.IsNullOrEmpty(layout)) return;
                var writter = new StreamWriter(stream);
                writter.AutoFlush = true;
                writter.Write(layout);

                stream.Position = 0;
                serializer.RestoreLayoutFromStream(stream, DevExpress.Utils.OptionsLayoutBase.FullLayout);
            }
        }

        public static void InitWithDefaultLayout(this ColumnView view, string entityName)
        {
            var defaultLayoutXml = GetDefaultLayout(entityName);
            view.RestoreLayoutFromString(defaultLayoutXml);
            var entity = MetadataRepository.Entities.Single(e => e.PhysicalName == entityName);

            var projections = GetColumnProjections(entityName);
            foreach (GridColumn column in view.Columns)
            {
                var filedName = column.FieldName;
                var attribute = entity.Attributes.FirstOrDefault(a => a.PhysicalName == filedName);
                if (attribute != null) InitColumn(column, attribute);

                var projection = projections.FirstOrDefault(p => p.PropertyPath == filedName);
                if (projection != null) column.FieldName = projection.Projection;
            }
        }

        private static void InitColumn(GridColumn column, EntityAttribute attribute)
        {
            var isComplexField = attribute.AttributeLookupValues.Any();
            if (isComplexField)
            {
                LocalizeRelatedField(column, attribute);
                return;
            }

            if (attribute.OptionSetId != null)
            {
                var lookUpEdit = new RepositoryItemLookUpEdit();
                lookUpEdit.BindPickList(attribute);
                column.ColumnEdit = lookUpEdit;
            }
            else if (attribute.LogicalName == "MultipleLineText")
            {
                var memoEdit = new RepositoryItemMemoEdit();
                column.ColumnEdit = memoEdit;
            }
            var localizedLabel = GetLocalizedLabel(attribute.AttributeId);
            if (string.IsNullOrEmpty(localizedLabel))
            {
                var captionAttribute = attribute.Entity.Attributes.FirstOrDefault(a => a.PhysicalName == column.Caption);
                if (captionAttribute != null) localizedLabel = GetLocalizedLabel(captionAttribute.AttributeId);
            }

            if (!string.IsNullOrEmpty(localizedLabel)) column.Caption = localizedLabel;
        }

        private static void LocalizeRelatedField(GridColumn column, EntityAttribute attribute)
        {
            var lookupValue = attribute.AttributeLookupValues.First();
            var childAttribute = lookupValue.Entity.Attributes.First(a => a.AttributeId == lookupValue.DisplayEntityAttributeId);

            var caption = string.Empty;
            
            var fieldSegments = column.FieldName.Split('.');
            if (fieldSegments.Length == 2)
            {
                childAttribute = lookupValue.Entity.Attributes.First(a => a.PhysicalName == fieldSegments[1]);
                var mainLocalizedLabel = GetLocalizedLabel(attribute.AttributeId);
                var subLocalizedLabel = GetLocalizedLabel(childAttribute.AttributeId);
                caption = string.Format("{0}{1}", mainLocalizedLabel ?? string.Empty, subLocalizedLabel);
            }
            else
                caption = GetLocalizedLabel(attribute.AttributeId);
            column.Caption = caption;
        }

        private static string GetLocalizedLabel(Guid attributeId)
        {
            int langId = CultureManager.CurrentCulture.LCID;
            var label = MetadataRepository.LocalizedLabels.FirstOrDefault(l => l.ObjectId == attributeId && l.LanguageId == langId);
            if (label != null) return label.Label;
            return null;
        }

        private static string GetDefaultLayout(string entityName)
        {
            var entity = MetadataRepository.Entities.Single(e => e.PhysicalName == entityName);

            var savedQueries = MetadataRepository.GetSavedQuery(entity.EntityId);

            var defaultQuery = savedQueries.FirstOrDefault(q => q.QueryType == 0 && q.IsDefault);
            if (defaultQuery == null) defaultQuery = savedQueries.FirstOrDefault();
            if (defaultQuery == null)
            {
                throw new Exception("This is no default list view layout for " + entityName);
            }
            return defaultQuery.LayoutXml;
        }

        public static List<ColumnProjection> GetColumnProjections(string entityName)
        {
            var entity = MetadataRepository.Entities.Single(e => e.PhysicalName == entityName);
            GridView gridView = new GridView();
            var defaultLayoutXml = GetDefaultLayout(entityName);
            gridView.RestoreLayoutFromString(defaultLayoutXml);
            var projections = gridView.Columns.Cast<GridColumn>()
                .Where(column => !string.IsNullOrEmpty(column.FieldName))
                .Select(column => new ColumnProjection(column.FieldName, entity)).ToList();
            gridView.Dispose();
            gridView = null;
            ColumnProjection keyColumnProjection = new ColumnProjection(entityName + "Id", entity);
            if (!projections.Contains(keyColumnProjection)) projections.Add(keyColumnProjection);
            return projections;
        }
    }
}
