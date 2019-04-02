using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Katrin.AppFramework.Utils
{
    public interface IUserVisibleException
    {
    }

    public class MessageDialog
    {
		private WinApplication application;
        public MessageDialog(WinApplication application)
        {
            this.application = application;
        }
        protected WinApplication Application
        {
			get { return application; }
		}

		protected virtual DialogResult ShowCore(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon) {
			return XtraMessageBox.Show(Form.ActiveForm, message, caption, buttons, icon);
		}
		protected virtual void ShowSystemException(string caption, string exceptionMessage) {
			ExceptionDialogForm.ShowMessage(caption, exceptionMessage);
		}
		protected virtual void ShowSystemException(string caption, Exception exception) {
			ShowSystemException(caption, exception.Message);
		}
		public DialogResult Show(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon) {			
			DialogResult result = ShowCore(message, caption, buttons, icon);
			return result;
		}		
		public DialogResult Show(string caption, string message) {
			return Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.None);
		}
		public void Show(Exception exception) {
			Show((application == null) ? CaptionHelper.GetLocalizedText("Texts", "Error") : application.Title, exception);
		}
		public void Show(string caption, Exception exception) {
            if (exception is IUserVisibleException)
            {
				Show(CaptionHelper.GetLocalizedText("Texts", "Error"), exception.Message);
			}
			else {
				ShowSystemException(caption, exception.Message);
			}
		}
		public DialogResult GetUserChoice(string message, string caption, MessageBoxButtons buttons) {
			return Show(message, caption, buttons, MessageBoxIcon.Warning);
		}
    }
}
