using System;
namespace Katrin.AppFramework.WinForms.Services
{
    partial class ExceptionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            GC.Collect();
            GC.SuppressFinalize(this);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionForm));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblInfo = new DevExpress.XtraEditors.LabelControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblAdvise = new DevExpress.XtraEditors.LabelControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSend = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnDetails = new DevExpress.XtraEditors.SimpleButton();
            this.txtExceptionDeatil = new DevExpress.XtraEditors.MemoEdit();
            this.pnlTop.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtExceptionDeatil.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.panel2);
            this.pnlTop.Controls.Add(this.panel4);
            this.pnlTop.Controls.Add(this.panel3);
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Name = "pnlTop";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblInfo);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // lblInfo
            // 
            resources.ApplyResources(this.lblInfo, "lblInfo");
            this.lblInfo.Name = "lblInfo";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblAdvise);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // lblAdvise
            // 
            resources.ApplyResources(this.lblAdvise, "lblAdvise");
            this.lblAdvise.Name = "lblAdvise";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSend);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.btnDetails);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // btnSend
            // 
            resources.ApplyResources(this.btnSend, "btnSend");
            this.btnSend.Name = "btnSend";
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDetails
            // 
            resources.ApplyResources(this.btnDetails, "btnDetails");
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // txtExceptionDeatil
            // 
            resources.ApplyResources(this.txtExceptionDeatil, "txtExceptionDeatil");
            this.txtExceptionDeatil.Name = "txtExceptionDeatil";
            this.txtExceptionDeatil.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("txtExceptionDeatil.Properties.Appearance.BackColor")));
            this.txtExceptionDeatil.Properties.Appearance.Options.UseBackColor = true;
            this.txtExceptionDeatil.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtExceptionDeatil.Properties.ReadOnly = true;
            // 
            // ExceptionForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtExceptionDeatil);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExceptionForm";
            this.Load += new System.EventHandler(this.frmExceptionForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtExceptionDeatil.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.LabelControl lblInfo;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.SimpleButton btnSend;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnDetails;
        private DevExpress.XtraEditors.MemoEdit txtExceptionDeatil;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.LabelControl lblAdvise;

    }
}
