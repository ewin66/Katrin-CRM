using System;
namespace Katrin.Win.DetailViewModule
{
    partial class DetailView
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
            if (this.EntityBindingSource != null)
            {
                this.EntityBindingSource.Dispose();
            }
            EntityBindingSource.DataSource = null;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EntityBindingSource = new System.Windows.Forms.BindingSource();
            this.ValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.messagePanel = new DevExpress.Utils.Frames.NotePanel8_1();
            this.EntityDataLayoutControl = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.RootLayoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // messagePanel
            // 
            this.messagePanel.BackColor2 = System.Drawing.Color.WhiteSmoke;
            this.messagePanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.messagePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.messagePanel.Location = new System.Drawing.Point(0, 0);
            this.messagePanel.Name = "messagePanel";
            this.messagePanel.Size = new System.Drawing.Size(906, 33);
            this.messagePanel.TabIndex = 5;
            this.messagePanel.TabStop = false;
            this.messagePanel.Visible = false;
            // 
            // EntityDataLayoutControl
            // 
            this.EntityDataLayoutControl.DataSource = this.EntityBindingSource;
            this.EntityDataLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EntityDataLayoutControl.Location = new System.Drawing.Point(0, 33);
            this.EntityDataLayoutControl.Name = "EntityDataLayoutControl";
            this.EntityDataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(429, 29, 250, 350);
            this.EntityDataLayoutControl.Root = this.RootLayoutControlGroup;
            this.EntityDataLayoutControl.Size = new System.Drawing.Size(906, 667);
            this.EntityDataLayoutControl.TabIndex = 6;
            this.EntityDataLayoutControl.Text = "LayoutControl";
            // 
            // RootLayoutControlGroup
            // 
            this.RootLayoutControlGroup.CustomizationFormText = "Root";
            this.RootLayoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.RootLayoutControlGroup.GroupBordersVisible = false;
            this.RootLayoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.RootLayoutControlGroup.Name = "RootLayoutControlGroup";
            this.RootLayoutControlGroup.Size = new System.Drawing.Size(906, 667);
            this.RootLayoutControlGroup.Text = "Root";
            this.RootLayoutControlGroup.TextVisible = false;
            // 
            // DetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EntityDataLayoutControl);
            this.Controls.Add(this.messagePanel);
            this.Name = "DetailView";
            this.Size = new System.Drawing.Size(906, 700);
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityDataLayoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootLayoutControlGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.BindingSource EntityBindingSource;
        protected DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider ValidationProvider;
        private DevExpress.Utils.Frames.NotePanel8_1 messagePanel;
        protected DevExpress.XtraDataLayout.DataLayoutControl EntityDataLayoutControl;
        protected DevExpress.XtraLayout.LayoutControlGroup RootLayoutControlGroup;
    }
}
