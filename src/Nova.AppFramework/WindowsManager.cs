using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Katrin.AppFramework
{
    /// <summary>
    /// A service that manages windows.
    /// </summary>
    public interface IWindowManager
    {
        /// <summary>
        /// Shows a modal dialog for the specified model.
        /// </summary>
        /// <param name="rootModel">The root model.</param>
        /// <param name="context">The context.</param>
        /// <returns>The dialog result.</returns>
        DialogResult ShowDialog(object rootModel, object context = null);

        /// <summary>
        /// Shows a non-modal window for the specified model.
        /// </summary>
        /// <param name="rootModel">The root model.</param>
        /// <param name="context">The context.</param>
        void ShowWindow(object rootModel, object context = null);
    }

    /// <summary>
    /// A service that manages windows.
    /// </summary>
    public class WindowManager : IWindowManager
    {
        /// <summary>
        /// Shows a modal dialog for the specified model.
        /// </summary>
        /// <param name="rootModel">The root model.</param>
        /// <param name="context">The context.</param>
        /// <returns>The dialog result.</returns>
        public virtual DialogResult ShowDialog(object rootModel, object context = null)
        {
            return CreateWindow(rootModel, true, context).ShowDialog();
        }

        /// <summary>
        /// Shows a window for the specified model.
        /// </summary>
        /// <param name="rootModel">The root model.</param>
        /// <param name="context">The context.</param>
        public virtual void ShowWindow(object rootModel, object context = null)
        {
            CreateWindow(rootModel, false, context).Show();
        }

        /// <summary>
        /// Creates a window.
        /// </summary>
        /// <param name="rootModel">The view model.</param>
        /// <param name="isDialog">Whethor or not the window is being shown as a dialog.</param>
        /// <param name="context">The view context.</param>
        /// <returns>The window.</returns>
        protected virtual Form CreateWindow(object rootModel, bool isDialog, object context)
        {
            var view = new XtraForm();

            new WindowConductor(rootModel, view);

            return view;
        }

        class WindowConductor
        {
            bool deactivatingFromView;
            bool deactivateFromViewModel;
            bool actuallyClosing;
            readonly Form view;
            readonly object model;

            public WindowConductor(object model, Form view)
            {
                this.model = model;
                this.view = view;

                var activatable = model as IActivate;
                if (activatable != null)
                    activatable.Activate();

                var deactivatable = model as IDeactivate;
                if (deactivatable != null)
                {
                    view.Closed += Closed;
                    deactivatable.Deactivated += Deactivated;
                }

                var guard = model as IGuardClose;
                if (guard != null)
                    view.Closing += Closing;
            }

            void Closed(object sender, EventArgs e)
            {
                view.Closed -= Closed;
                view.Closing -= Closing;

                if (deactivateFromViewModel)
                    return;

                var deactivatable = (IDeactivate)model;

                deactivatingFromView = true;
                deactivatable.Deactivate(true);
                deactivatingFromView = false;
            }

            void Deactivated(object sender, DeactivationEventArgs e)
            {
                if (!e.WasClosed)
                    return;

                ((IDeactivate)model).Deactivated -= Deactivated;

                if (deactivatingFromView)
                    return;

                deactivateFromViewModel = true;
                actuallyClosing = true;
                view.Close();
                actuallyClosing = false;
                deactivateFromViewModel = false;
            }

            void Closing(object sender, CancelEventArgs e)
            {
                if (e.Cancel)
                    return;

                var guard = (IGuardClose)model;

                if (actuallyClosing)
                {
                    actuallyClosing = false;
                    return;
                }

                bool runningAsync = false, shouldEnd = false;

                guard.CanClose(canClose =>
                {
                    SynchronizationContext.Current.Send(o =>
                    {
                        if (runningAsync && canClose)
                        {
                            actuallyClosing = true;
                            view.Close();
                        }
                        else e.Cancel = !canClose;

                        shouldEnd = true;
                    }, null);
                });

                if (shouldEnd)
                    return;

                runningAsync = e.Cancel = true;
            }
        }
    }
}
