using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Katrin.AppFramework.WinForms.MVC;

namespace TestProjects
{
    public partial class view1 : DevExpress.XtraEditors.XtraUserControl,IView
    {
        public view1()
        {
            InitializeComponent();
        }

        private void view1_Load(object sender, EventArgs e)
        {

        }

        public event EventHandler Closed;

        public IControllerManager ControllerManager
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool IsChildForm
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public object Model
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string ViewName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string RibbonPath
        {
            get
            {
                return "/Lead/List/Ribbon";
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void BindDataToView()
        {
            throw new NotImplementedException();
        }

        public void ShowView()
        {
            throw new NotImplementedException();
        }

        public void ActiveView()
        {
            throw new NotImplementedException();
        }

        public void CloseView()
        {
            throw new NotImplementedException();
        }


        public string ViewType
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
