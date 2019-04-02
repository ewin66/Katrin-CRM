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
using Katrin.Win.Common.Core;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeUI.SmartParts;

namespace Katrin.Win.MainModule.Views.SystemSetting
{
   [SmartPart]
    public partial class ConfigurationList : AbstractDetailView, ISystemSettingListView
    {
        private SystemSettingListPresenter _presenter;
        [CreateNew]
        public SystemSettingListPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
        }

        public GridView GridView
        {
            get { return configurationConditionGrid; }
        }

        public IEnumerable<object> Configurations
        {
            get { return null; }
            //get { return configurationBindingSource.List.Cast<SystemSetting>(); }
        }

        public ConfigurationList()
        {
            InitializeComponent();
        }

        public event EventHandler OK;
        public void OnOK(EventArgs e)
        {
            EventHandler handler = OK;
            if (handler != null) handler(this, e);
        }

        public void Bind(List<object> configurations)
        {
            foreach (object configuration in configurations)
            {
                int position = configurationBindingSource.Add(configuration);
                configurationBindingSource.Position = position;
            }
        }

        public void ShowMessage(string message)
        {
            XtraMessageBox.Show(this, message, Properties.Resources.Katrin, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            OnOK(e);
            //Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Close();
        }


        public DialogResult ShowDialog()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }
    }
}
