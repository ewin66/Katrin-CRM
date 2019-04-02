using System;
using System.Collections.Generic;
using Katrin.Win.Common.Core;
using Microsoft.Practices.ObjectBuilder;
using Katrin.Win.Common.MetadataServiceReference;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Katrin.Win.Common;
using System.Collections;

namespace Katrin.Win.MetadataManager
{
    public partial class MetadataDetailView : AbstractDetailView, IMetadataDetailView
    {
        private MetadataDetailPresenter _presenter;
        /// <summary>
        /// Sets the presenter. The dependency injection system will automatically
        /// create a new presenter for you.
        /// </summary>
        [CreateNew]
        public MetadataDetailPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        public MetadataDetailView()
        {
            InitializeComponent();
        }

        public void Bind(List<Common.MetadataServiceReference.Entity> entity)
        {
            EntityBindingSource.DataSource = entity;
            var metadataService = MetadataProvider.CreateServiceClient();
            savedQueryBindingSource.DataSource = metadataService.GetSavedQuery(entity[0].EntityId);
        }

        private void addAttributeButton_Click(object sender, EventArgs e)
        {
            _presenter.ShowAttributeDetail(Guid.Empty);
        }

        private void editAttributeButton_Click(object sender, EventArgs e)
        {
            if (attributesBindingSource.Current != null)
            {
                EntityAttribute attibue = attributesBindingSource.Current as EntityAttribute;
                if(attibue != null)
                    _presenter.ShowAttributeDetail(attibue.AttributeId);
            }
        }

        public override void PostEditors()
        {
            base.PostEditors();
            attributeGridView.PostEditor();
        }

        public void SetControlState(Guid entityId)
        {
            //bool state = true;
            //if (entityId == Guid.Empty)
            //{
            //    state = false;
            //}
            //addAttributeButton.Enabled = state;
            //editAttributeButton.Enabled = state;
            //deleteAttributeButton.Enabled = state;
            //attributeGridView.OptionsBehavior.Editable = !state;
        }

        public void SelectTab(int tabIndex)
        {
            tabbedControlGroup.SelectedTabPageIndex = tabIndex;
        }

        private void deleteAttributeButton_Click(object sender, EventArgs e)
        {
            if (attributesBindingSource.Current != null)
            {
                EntityAttribute attibue = attributesBindingSource.Current as EntityAttribute;
                if (attibue != null)
                {
                    string message = "Do you confirm to delete this attribute?";
                    if (XtraMessageBox.Show(message,Properties.Resources.Katrin, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        _presenter.DeleteAttribute(attibue.AttributeId);
                    }
                }
            }
        }

        private void tabbedControlGroup_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            string text = NameTextEdit.Text;
            NameTextEdit.Text = "";
            NameTextEdit.Text = text;
        }

        private void addViewButton_Click(object sender, EventArgs e)
        {
            Entity entity = EntityBindingSource.Current as Entity;
            Guid atrributeId = entity.EntityId;
            SavedQuery query = new SavedQuery();
            query.ReturnedTypeId = atrributeId;
            _presenter.ShowSavedQueryDetail(query);
        }

        private void editViewButton_Click(object sender, EventArgs e)
        {
            var query = queryGridView.GetRow(queryGridView.FocusedRowHandle) as SavedQuery;
            _presenter.ShowSavedQueryDetail(query);
        }

        private void deleteViewButton_Click(object sender, EventArgs e)
        {
            if (savedQueryBindingSource.Current != null)
            {
                SavedQuery savedQuery = savedQueryBindingSource.Current as SavedQuery;
                if (savedQuery != null)
                {
                    string message = "Do you confirm to delete this Entity View?";
                    if (XtraMessageBox.Show(message, Properties.Resources.Katrin, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        _presenter.DeleteView(savedQuery.SavedQueryId);
                    }
                }
            }
        }

        private void savedQueryBindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            IList list = savedQueryBindingSource.DataSource as IList;
            if (list == null) return;
            if (list.Count <= 1) deleteViewButton.Enabled = false;
            else deleteViewButton.Enabled = true;
        }
    }
}
