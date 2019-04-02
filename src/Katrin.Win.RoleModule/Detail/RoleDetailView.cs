using System;
using System.Linq;
using Katrin.AppFramework.MetadataServiceReference;
using Katrin.Win.DetailViewModule;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework.WinForms.Messages;
using DevExpress.XtraEditors.DXErrorProvider;
using Katrin.Win.RoleModule;
using DevExpress.XtraEditors;
using System.Collections.Generic;

namespace Katrin.Win.RoleModule.Detail
{
    public partial class RoleDetailView : DetailView, IRoleDetailView
    {
        public RoleDetailView()
        {
            InitializeComponent();
        }
        private RoleViewModel role { get; set; }
        public event EventHandler Search;
        public void OnSearch(EventArgs e)
        {
            EventHandler handler = Search;
            if (handler != null) handler(this, e);
        }

        public override void Bind(object data)
        {
            var roleDetail = (RoleViewModel) data;
            var list = new List<RoleViewModel> { roleDetail };
            EntityBindingSource.DataSource = list;
            roleMenuActionsBindingSource.DataMember = "SelectedEntities";
            menuGridView.RefreshData();
            menuGridView.Focus();
            actionBindingSource.DataMember = "Privileges";
            role = roleDetail;
            ForeceTabGroupInitialize();
        }

        public override void InitValidation()
        {

        }

        public override void PostEditors()
        {
            base.PostEditors();
            gridActionView.PostEditor();
        }

        private void btnSreach_Click(object sender, EventArgs e)
        {
            OnSearch(e);
        }

        public event EventHandler MenuSelecting;

        public void InitRelationMenus(List<Entity> entities)
        {
            if (MenuSelecting != null)
            {
                MenuSelecting(this, EventArgs.Empty);
            }
        }
 }
}
