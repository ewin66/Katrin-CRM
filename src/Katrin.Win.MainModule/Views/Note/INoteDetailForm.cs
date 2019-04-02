using System;
using System.Windows.Forms;
using Katrin.Win.Common.Core;

namespace Katrin.Win.MainModule.Views.Note
{
    public interface INoteDetailForm : IEntityDetailView
    {
        event EventHandler Saved;
        bool ShowCheckOptions { set; }
        bool UpdateLatestFeadback { get; }
        bool AppandDescription { get; }
        void Close(DialogResult result);
        void SetDescriptionVisible(bool isVisible);
        void SetModifyEditVisible(bool isVisible);
    }
}
