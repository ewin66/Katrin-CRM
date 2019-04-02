
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms.Views;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Katrin.AppFramework.WinForms.Messages;
using System.Drawing;

namespace Katrin.AppFramework.WinForms.Workspaces
{
    public enum ViewShowType
    {
        Mdi,
        Show,
        Dialog
    }

    public class MdiWorkspace: IWorkspace
    {
        private Form _OwnerForm = null;
        private TabbedView _tabbedView;
       
        

        public MdiWorkspace(TabbedView tabbedView,Form ownerForm)
        {
            this._OwnerForm = ownerForm;
            this._tabbedView = tabbedView;
            this._tabbedView.DocumentDeactivated += _tabbedView_DocumentDeactivated;
            this._tabbedView.DocumentActivated += _tabbedView_DocumentActivated;
            this._tabbedView.DocumentClosing += _tabbedView_DocumentClosing;
            this._tabbedView.DocumentAdded += _tabbedView_DocumentAdded;
            this._tabbedView.DocumentClosed += _tabbedView_DocumentClosed;
        }

        void _tabbedView_DocumentDeactivated(object sender, DocumentEventArgs e)
        {
            IWorkspace1 workspace = e.Document.Control as IWorkspace1;
            if (workspace != null)
                workspace.Deactivated();
        }

        void _tabbedView_DocumentClosed(object sender, DocumentEventArgs e)
        {
            if (this._tabbedView.ActiveDocument == null)
            {
                string Katrin = ResourceService.GetString("Katrin");
                _OwnerForm.Text = Katrin;
            }
           
        }

        void _tabbedView_DocumentAdded(object sender, DocumentEventArgs e)
        {
            IWorkspace1 workspace = e.Document.Control as IWorkspace1;
            var icon = WinFormsResourceService.GetIcon(workspace.ObjectName.ToLower());
            
            if (icon != null)
                e.Document.Image = new Bitmap(icon.ToBitmap(), new Size(16, 16));
        }

        //setting main form text.
        void _tabbedView_DocumentActivated(object sender, DocumentEventArgs e)
        {
            
            string Katrin = ResourceService.GetString("Katrin");
            string format = "{0}-{1}";
            string title = string.Format(format, e.Document.Caption, Katrin);
            _OwnerForm.Text = title;
           
            //send msg to navbar
            SelectedWorkSpaceChanged workSpaceMsg = new  SelectedWorkSpaceChanged();
            IWorkspace1 workspace = e.Document.Control as IWorkspace1;
            workSpaceMsg.ModuleName = workspace.ObjectName;
            workSpaceMsg.WorkSpaceName = workspace.ObjectName;
            workspace.Activated();
            //workSpaceMsg.ObjectName = this.ObjectName;
            EventAggregationManager.SendMessage(workSpaceMsg);

        }
        void _tabbedView_DocumentClosing(object sender, DocumentCancelEventArgs e)
        {
            WorkSpaceClosed workSpaceMsg = new WorkSpaceClosed();
            IWorkspace1 workspace = e.Document.Control as IWorkspace1;
            workSpaceMsg.ModuleName = workspace.ObjectName;
            workSpaceMsg.WorkSpaceName = workspace.ObjectName;
      
            EventAggregationManager.SendMessage(workSpaceMsg);
        }
      

        public TabbedView TabbedView
        {
            get { return this._tabbedView; }
        }

        public void Show(Control view, ViewShowType showType)
        {
            var form = view as Form;
            if (form != null)
            {
                if (showType == ViewShowType.Dialog)
                {
                    form.ShowDialog();
                }
                else if (showType == ViewShowType.Mdi)
                {
                    _tabbedView.Manager.BeginUpdate();
                    form.MdiParent = _tabbedView.Manager.MdiParent;
                    form.Show();
                    _tabbedView.Manager.EndUpdate();
                }
                else
                {
                    form.Show();
                }
            }
            else
            {
                _tabbedView.AddDocument(view);
            }
            
        }

        public IEventAggregator EventAggregator
        {
            get { throw new NotImplementedException(); }
        }



        public void RestoreAllViewDefaultLayout()
        {
            
        }
    }


}
