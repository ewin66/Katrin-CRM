using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Katrin.Shell
{
    public static class LoadingFormManager
    {
        private static LoadingForm _loadingForm;

        public static void BeginLoading(Form owner)
        {
            Point parentCenter = Point.Empty;

            if (owner != null)
            {
                parentCenter = new Point((owner.Location.X + owner.Width / 2),
                                (owner.Location.Y + owner.Height / 2));
            }

            if (_loadingForm != null && !_loadingForm.IsDisposed) return;

            Thread thread = new Thread(() =>
            {
                _loadingForm = new LoadingForm();
                if (parentCenter != Point.Empty)
                {
                    _loadingForm.Location = new Point(parentCenter.X - _loadingForm.Width / 2, parentCenter.Y - _loadingForm.Height / 2);
                    _loadingForm.StartPosition = FormStartPosition.CenterScreen;
                }
                _loadingForm.TopMost = true;
                _loadingForm.ShowDialog();
            });
            thread.Start();
        }

        public static void EndLoading()
        {
            if (_loadingForm != null && !_loadingForm.IsDisposed && _loadingForm.IsHandleCreated)
                _loadingForm.Invoke(new Action(() =>
                {
                    _loadingForm.Close(); 
                    _loadingForm.Dispose(); 
                    _loadingForm = null;
                }));
        }
    }
}
