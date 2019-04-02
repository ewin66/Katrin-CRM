using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.MetadataServiceReference;
using Katrin.AppFramework.WinForms.MVC;
using DevExpress.XtraBars.Ribbon;

namespace Katrin.AppFramework.WinForms.ViewInterface
{
    public interface IObjectDetailView :IView
    {
        //UserDataPersistenceService UserDataPersistenceService { get; set; }
        event EventHandler ObjectChanged;
        void SetEditorStatus(bool isReadOnly);
        void InitEditors(Entity entity);
        void Bind(object entity);
        bool ValidateData();
        void PostEditors();
        void BeginInit();
        void EndInit();
        void Close();
    }
}
