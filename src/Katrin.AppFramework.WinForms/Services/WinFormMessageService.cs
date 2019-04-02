/// <summary>
/// winformmessageservice implement
/// author:hecq
/// date:2012-10-19
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.Core;

namespace Katrin.AppFramework.WinForms.Services
{
    class WinFormMessageService : ICSharpCode.Core.Services.IMessageService
    {
        private bool _CanDebug, _CanInfo, _CanWarn, _CanError;

        public WinFormMessageService() { }

        public WinFormMessageService(bool canDebug,
            bool canInfo,
            bool canWarn,
            bool canError)
        {
            _CanDebug = canDebug;
            _CanInfo = canInfo;
            _CanWarn = canWarn;
            _CanError = canError;
        }

        public bool IsDebugEnabled
        {
            get { return _CanDebug; }
        }

        public bool IsInfoEnabled
        {
            get { return _CanInfo; }
        }

        public bool IsWarnEnabled
        {
            get { return _CanWarn; }
        }

        public bool IsErrorEnabled
        {
            get { return _CanError; }
        }

        public void ShowError(string message)
        {
            var catption = ResourceService.GetString("Error");
            DevExpress.XtraEditors.XtraMessageBox.Show(message, catption,
               MessageBoxButtons.OK,
               MessageBoxIcon.Error,
               MessageBoxDefaultButton.Button1);
        }

        public void ShowException(Exception ex, string message)
        {
            ExceptionForm frmEx = new ExceptionForm(message, ex);
            frmEx.ShowDialog();
        }

        public void ShowWarning(string message)
        {
            var caption = ResourceService.GetString("Warn");
            DevExpress.XtraEditors.XtraMessageBox.Show(message, caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
        }

        public bool AskQuestion(string question, string caption)
        {
            DialogResult result = DevExpress.XtraEditors.XtraMessageBox.Show(question, caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            return result == DialogResult.Yes;
        }

        public DialogResult AskQuestionYesNoCancel(string question, string caption)
        {
            DialogResult result = DevExpress.XtraEditors.XtraMessageBox.Show(question, caption,
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1);
            return result ;
        }

        public int ShowCustomDialog(string caption, string dialogText, int acceptButtonIndex, int cancelButtonIndex, params string[] buttontexts)
        {
            throw new NotImplementedException();
        }

        public string ShowInputBox(string caption, string dialogText, string defaultValue)
        {
            throw new NotImplementedException();
        }

        public void ShowMessage(string message, string caption)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show(message, caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
        }

        public void InformSaveError(string fileName, string message, string dialogName, Exception exceptionGot)
        {
            throw new NotImplementedException();
        }

        public ICSharpCode.Core.Services.ChooseSaveErrorResult ChooseSaveError(string fileName, string message, string dialogName, Exception exceptionGot, bool chooseLocationEnabled)
        {
            throw new NotImplementedException();
        }
    }
}
