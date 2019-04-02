using System;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Windows.Forms;
using System.Collections.Generic;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.MetadataServiceReference;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeUI.SmartParts;

namespace Katrin.Win.MainModule.Views.Role
{
    [SmartPart]
    public partial class RoleDetailView : AbstractDetailView, IRoleDetailView
    {
        private RoleDetailPresenter _presenter;
        [CreateNew]
        public RoleDetailPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }
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
