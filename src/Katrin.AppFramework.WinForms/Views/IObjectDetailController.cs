using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Messages;

namespace Katrin.AppFramework.WinForms.Views
{
    public interface IObjectDetailController : IObjectAware
    {
        Guid ObjectId { get; set; }
        bool OnSave();
        bool SaveAndClose();
        bool CopyAndNew();
        EntityDetailWorkingMode WorkingMode { get; set; }
        bool HasChanges { get; }
        void SetLoadedComplete();
        void SetEditorStatus();
    }
}
