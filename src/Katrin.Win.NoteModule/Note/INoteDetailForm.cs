using System;
using System.Windows.Forms;
using Katrin.AppFramework.WinForms.ViewInterface;
namespace Katrin.Win.NoteModule.Note
{
    public interface INoteDetailForm : IObjectDetailView
    {
        event EventHandler Saved;
        bool ShowCheckOptions { set; }
        bool UpdateLatestFeadback { get; }
        bool AppandDescription { get; }
        void SetDescriptionVisible(bool isVisible);
        void SetModifyEditVisible(bool isVisible);
    }
}
