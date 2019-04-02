using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Runtime.Serialization.Formatters.Binary;
using DevExpress.Utils;
using System.Reflection;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;

namespace Katrin.Win.MainModule.Views.User
{
    [SmartPart]
    public partial class UserRoleListView : XtraForm, IUserRoleListView
    {
        private UserRoleListPresenter _presenter;
        private readonly List<RoleModel> _selectedRoles = new List<RoleModel>();

        [CreateNew]
        public UserRoleListPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }
        public List<Guid> SelectedRoles
        {
            get
            {
                return roleBindingSource.List.Cast<RoleModel>().Where(role=>role.IsSelected).Select(role => role.RoleId).ToList();
            }
        }

        public UserRoleListView()
        {
            InitializeComponent();
            //_gridViewBehavior = new EntityGridViewBehavior<RoleModel>(roleGridView);
        }
        public event EventHandler OK;
        public event EventHandler OnClose;
        public void OnOK(EventArgs e)
        {
            EventHandler handler = OK;
            if (handler != null) handler(this, e);
        }
        public void BindRole(List<RoleModel> roles)
        {
            roleBindingSource.DataSource = roles;
        }
        public void PostEditors()
        {
            roleGridView.PostEditor();
        }
        public void ShowView()
        {
            this.ShowDialog();
        }

        public void ShowMessage(string message)
        {
            XtraMessageBox.Show(this, message, Properties.Resources.Katrin, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            OnOK(e);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EventHandler handler = OnClose;
            if (handler != null) handler(this, e);
            Close();
        }

       
    }
}
