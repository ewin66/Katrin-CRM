using System;
using System.Linq;
using Katrin.Win.Common.Constants;
using Katrin.Win.Infrastructure;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Layout;
using Microsoft.Practices.CompositeUI.EventBroker;
using Katrin.Win.Common.MetadataServiceReference;
using System.Collections.Generic;
using Katrin.Win.Common.Security;

namespace Katrin.Win.Common.Core
{
    public partial class EntityListView : RecordListView
    {
        [EventPublication(EventTopicNames.RowDoubleClick, PublicationScope.WorkItem)]
        public event EventHandler<EventArgs<object>> RowDoubleClick;

        [EventPublication(EventTopicNames.ConvertDetail, PublicationScope.WorkItem)]
        public event EventHandler<EventArgs<string>> ConvertDetail;

        public void OnRowDoubleClick(EventArgs<object> e)
        {
            EventHandler<EventArgs<object>> handler = RowDoubleClick;
            if (handler != null) handler(this, e);
        }

        protected override void EntityGridViewDoubleClick(object sender, EventArgs e)
        {
            var view = (ColumnView)sender;
            var pt = view.GridControl.PointToClient(MousePosition);

            var gridView = view as GridView;
            if (gridView != null)
            {
                GridHitInfo info = gridView.CalcHitInfo(pt);
                if (!info.InRow && !info.InRowCell)
                    return;
                OnRowDoubleClick(new EventArgs<object>(SelectedEntity));
            }
            var layoutView = view as LayoutView;
            if(layoutView!=null)
            {
                var info = layoutView.CalcHitInfo(pt);
                if(info.InField) OnRowDoubleClick(new EventArgs<object>(SelectedEntity));
            }
        }

        public EntityListView()
        {
            InitializeComponent();
        }

        public void RefreshList(string entityName)
        {
            var filterCriteria = Context.GetFilters();
            EntityGridView.BindDataAsync(Context, entityName, null, filterCriteria, IncludingPath);
        }

        #region convert
        public void OnConvertEntity(object entityName)
        {
            EventHandler<EventArgs<string>> handler = ConvertDetail;
            if (handler != null) handler(this, new EventArgs<string>(entityName.ToString()));
        }

        protected override void InitConvert()
        {
            List<ColumnMapping> mappingList = MetadataProvider.Instance.MappingList
                .Where(c => c.SourceEntityName == EntityName).ToList();
            var toConverList = mappingList.Select(c=>c.TargetEntityName).Distinct();
            foreach (string commandName in toConverList)
            {
                if (!AuthorizationManager.CheckAccess(commandName, "Write")) continue;
                RegisterPoupMenuItem(commandName,"Covert", commandName, OnConvertEntity);
            }
        }

        #endregion

        //protected override void OnFilterChanged(object sender, EventArgs e)
        //{
        //    base.OnFilterChanged(sender, e);
        //    EntityGridView.Focus();
        //}
    }
}
