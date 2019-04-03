using Katrin.AppFramework.WinForms.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework.WinForms.CommandManage;

namespace Katrin.AppFramework.WinForms.Workspaces
{
    public interface IWorkspaceInfo
    {
        /// <summary>
        /// WorkSpace id
        /// </summary>
        Guid ID { get; }
        /// <summary>
        /// Get actived view
        /// </summary>
        IView ActiveView { get; }
        /// <summary>
        /// All Views
        /// </summary>
        ReadOnlyCollection<IView> Views { get; }
        bool IsViewShowing(string viewId);
        void ActiveWorkSpaceWindow();
    }
    /// <summary>
    /// workspace form
    /// date:2012-10-29
    /// </summary>
    public interface IWorkspace1 : IObjectAware, IWorkspaceInfo, IControllerFinder
    {
        void AddView(IView view);
        string BasePath { get; set; }
        /// <summary>
        /// Remove view
        /// </summary>
        /// <param name="view"></param>
        void RemoveView(IView view);     
        /// <summary>
        /// load view settings from addin tree
        /// </summary>
        /// <param name="owner">the owner of the ribbon command</param>
        /// <param name="path">the path of the settings in the addintree</param>
        void LoadViews(ActionParameters parameters);
        /// <summary>
        /// workspaceTitle.
        /// </summary>
        string Title { get; set; }
        void UpdateCommandState();

        void Deactivated();

        void Activated();

    }
}
