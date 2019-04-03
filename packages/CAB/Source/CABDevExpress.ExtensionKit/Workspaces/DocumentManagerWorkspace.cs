using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CABDevExpress.Workspaces
{
    public class DocumentManagerWorkspace : Workspace<Control, WindowSmartPartInfo>
    {
        private DocumentManager _documentManager;
        public DocumentManagerWorkspace(DocumentManager documentManager)
        {
            _documentManager = documentManager;
        }

        protected override void OnActivate(Control smartPart)
        {
            BaseDocument document;
            if (_documentManager.View.Documents.TryGetValue(smartPart, out document))
            {
                _documentManager.View.Controller.Activate(document);
            }
        }

        protected override void OnApplySmartPartInfo(Control smartPart, WindowSmartPartInfo smartPartInfo)
        {
        }

        protected override void OnShow(Control smartPart, WindowSmartPartInfo smartPartInfo)
        {
            _documentManager.View.BeginUpdate();
            BaseDocument document;
            if (smartPart is Form)
            {
                ((Form)smartPart).MdiParent = _documentManager.MdiParent;
                smartPart.Show();
            }
            if (!_documentManager.View.Documents.TryGetValue(smartPart, out document))
            {
                document = _documentManager.View.Controller.AddDocument(smartPart);
                smartPart.Show();
            }
            else
            {
                _documentManager.View.Controller.Activate(document);
            }
            _documentManager.View.EndUpdate();
        }

        protected override void OnHide(Control smartPart)
        {
        }

        protected override void OnClose(Control smartPart)
        {
            BaseDocument document;
            if (_documentManager.View.Documents.TryGetValue(smartPart, out document))
            {
                _documentManager.View.Controller.Close(document);
            }
        }
    }
}
