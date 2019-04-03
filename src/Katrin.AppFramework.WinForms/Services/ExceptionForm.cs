using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ICSharpCode.Core;

namespace Katrin.AppFramework.WinForms.Services
{
    /// <summary>
    /// Exception Info Form
    /// date:2012-10-19
    /// </summary>
    public partial class ExceptionForm :XtraForm
    {
        // DevExpress.XtraEditors.XtraMessageBoxForm
        private bool _IsExtend = false;
        private string _Message;
        private Exception _Exception;

        //resource keys
        public ExceptionForm(string msg,Exception ex)
        {
            InitializeComponent();
            _Message = msg;
            _Exception = ex;
        }

        private const string btnCloseCaption = "btnCloseCaption";
        private const string btnDetailCaption = "btnDetailCaption";
        private const string btnSendExInfoCaption = "btnSendExInfoCaption";
        private const string frmException_suggestion = "frmException_suggestion";
        private const string frmException_Text = "frmException_Text";
        private const string frmExceptionTitle = "frmExceptionTitle";

        //btnCloseCaption	Close	????
        //btnDetailCaption	Detail	????
        //btnSendExInfoCaption	SendExceptionInfo	????
        //frmException_suggestion	We strongly recommend you send the exception info to Katrin workgroup.	????
        //frmException_Text	System  encountered an exception because:\n{0};	????
        //frmExceptionTitle	ExceptionInfo	????

        private void btnDetails_Click(object sender, EventArgs e)
        {
            this._IsExtend = !this._IsExtend;
            if (this._IsExtend)
            {
                this.Height = 551;
            }
            else
            {
                this.Height = 296;
            }
          
        }

        private void frmExceptionForm_Load(object sender, EventArgs e)
        {
            try
            {
                //Get text formats in resourceFile.
                string strMsgText = ResourceService.GetString(frmException_Text);
                string strCloseCaption = ResourceService.GetString(ExceptionForm.btnCloseCaption);
                string strDetailCaption = ResourceService.GetString(ExceptionForm.btnDetailCaption);

                string strSendCaption = ResourceService.GetString(ExceptionForm.btnSendExInfoCaption);
                string strAdvise = ResourceService.GetString(ExceptionForm.frmException_suggestion);
                string strFormTitle = ResourceService.GetString(ExceptionForm.frmExceptionTitle);

                //set text to controls.
                this.Text = strFormTitle;
                this.btnClose.Text = strCloseCaption;
                this.btnDetails.Text = strDetailCaption;

                this.btnSend.Text = strSendCaption;
                this.lblAdvise.Text = strAdvise;
                

                this.lblInfo.Text = string.Format(strMsgText, this._Message);
                this.txtExceptionDeatil.Text = this._Exception.ToString();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   MessageBoxDefaultButton.Button1);
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        
    }
}
