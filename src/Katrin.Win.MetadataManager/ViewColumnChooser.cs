using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Katrin.Win.Common;
using Microsoft.Data.Edm;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;

namespace Katrin.Win.MetadataManager
{
    public partial class ViewColumnChooser : UserControl
    {
        private GridView _gridView;

        public ViewColumnChooser()
        {
            InitializeComponent();
        }

        public void Init(Guid entityId, GridView gridView)
        {
            _gridView = gridView;
            var entityMeta = MetadataProvider.Instance.EntiyMetadata.Single(e => e.EntityId == entityId);
            var entityType = DynamicDataServiceContext.GetTypeDefinition(entityMeta.PhysicalName);
            List<string> allFields = PopuldateFieldList(entityType).ToList();
            List<string> selectedFields = gridView.Columns.Cast<GridColumn>().Select(c => c.FieldName).ToList();
            List<string> availableFields = allFields.Except(selectedFields).ToList();
            fieldsListBox.DataSource = availableFields;
            columnsListBox.DataSource = selectedFields;
        }

        private static IEnumerable<string> PopuldateFieldList(IEdmEntityType entityType)
        {
            foreach (var property in entityType.StructuralProperties())
            {
                yield return property.Name;
            }
            foreach (var property in entityType.NavigationProperties())
            {
                var typeKind = property.Type.TypeKind();
                if (typeKind == EdmTypeKind.Entity)
                {
                    var navigationPropertyType = property.Type.AsEntity();
                    foreach (var childProperty in navigationPropertyType.StructuralProperties())
                    {
                        string propertyName = string.Format("{0}.{1}", property.Name, childProperty.Name);
                        yield return propertyName;
                    }
                }
            }
        }

        private void ApplyChanges()
        {
            List<GridColumn> existingColumns = new List<GridColumn>();
            List<string> addedColumns = new List<string>();
            var selectedColumns = columnsListBox.DataSource as List<string>;
            foreach (string fieldName in selectedColumns)
            {
                var column = _gridView.Columns.ColumnByFieldName(fieldName);
                if (column != null) existingColumns.Add(column);
                else addedColumns.Add(fieldName);
            }
            var removedColumns = _gridView.Columns.Cast<GridColumn>().Except(existingColumns).ToList();
            removedColumns.ForEach(c => _gridView.Columns.Remove(c));
            addedColumns.ForEach(f =>
            {
                var gridColumn = new GridColumn { FieldName = f };
                _gridView.Columns.Add(gridColumn);
            });
            _gridView.UpdateColumnsCustomization();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            if (ParentForm != null) ParentForm.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (ParentForm != null) ParentForm.Close();
        }

        Point p = Point.Empty;
        private void fieldsListBox_MouseDown(object sender, MouseEventArgs e)
        {
            ListBoxControl c = sender as ListBoxControl;
            p = new Point(e.X, e.Y);
            int selectedIndex = c.IndexFromPoint(p);
            if (selectedIndex == -1)
                p = Point.Empty;
        }

        private void columnsListBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void fieldsListBox_MouseMove(object sender, MouseEventArgs e)
        {
            ListBoxControl c = sender as ListBoxControl;
            if (e.Button == MouseButtons.Left)
                if ((p != Point.Empty) && ((Math.Abs(e.X - p.X) > 5) || (Math.Abs(e.Y - p.Y) > 5)))
                    c.DoDragDrop(sender, DragDropEffects.Move);
        }

        private void columnsListBox_DragDrop(object sender, DragEventArgs e)
        {
            ListBoxControl listBox = sender as ListBoxControl;
            Point newPoint = new Point(e.X, e.Y);
            newPoint = listBox.PointToClient(newPoint);
            int targetIndex = listBox.IndexFromPoint(newPoint);
            int sourceIndex = fieldsListBox.IndexFromPoint(p);
            var draggedItem = fieldsListBox.GetItem(sourceIndex);
            (fieldsListBox.DataSource as List<string>).RemoveAt(sourceIndex);
            if(targetIndex == -1)
                (listBox.DataSource as List<string>).Add(draggedItem.ToString());
            else
                (listBox.DataSource as List<string>).Insert(targetIndex, draggedItem.ToString());
            listBox.Refresh();
        }

        private void moveRightButton_Click(object sender, EventArgs e)
        {
            MoveItem(fieldsListBox,columnsListBox);
        }

        private void MoveItem(ListBoxControl source, ListBoxControl target)
        {
            int sourceIndex = source.SelectedIndex;
            if (sourceIndex == -1) return;
            var selectedItem = source.GetItem(sourceIndex);
            if (selectedItem == null) return;
            (source.DataSource as List<string>).RemoveAt(sourceIndex);
            (target.DataSource as List<string>).Add(selectedItem.ToString());
            source.Refresh();
            target.Refresh();
        }

        private void MoveAllItems(ListBoxControl source, ListBoxControl target)
        {
            var sourceList = source.DataSource as List<string>;
            if (sourceList.Count == 0) return;
            (target.DataSource as List<string>).AddRange(sourceList);
            sourceList.Clear();
            source.Refresh();
            target.Refresh();
        }

        private void moveLeftButton_Click(object sender, EventArgs e)
        {
            MoveItem(columnsListBox, fieldsListBox);
        }

        private void moveAllRightButton_Click(object sender, EventArgs e)
        {
            MoveAllItems(fieldsListBox, columnsListBox);
        }

        private void moveAllLeftButton_Click(object sender, EventArgs e)
        {
            MoveAllItems(columnsListBox, fieldsListBox);
        }
    }
}
