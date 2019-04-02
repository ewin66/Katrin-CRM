using DevExpress.XtraPrinting.Preview;

namespace Katrin.Win.MainModule.Views.Reports
{
    partial class OpportunityReportView
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
            if (disposing && (_presenter != null))
            {
                _presenter.Dispose();
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpportunityReportView));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.printControl = new DevExpress.XtraPrinting.Control.PrintControl();
            this.rootGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.printingLayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rootGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingLayoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            resources.ApplyResources(this.layoutControl1, "layoutControl1");
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("layoutControl1.Appearance.DisabledLayoutGroupCaption.GradientMode")));
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.Image = ((System.Drawing.Image)(resources.GetObject("layoutControl1.Appearance.DisabledLayoutGroupCaption.Image")));
            this.layoutControl1.Appearance.DisabledLayoutItem.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("layoutControl1.Appearance.DisabledLayoutItem.GradientMode")));
            this.layoutControl1.Appearance.DisabledLayoutItem.Image = ((System.Drawing.Image)(resources.GetObject("layoutControl1.Appearance.DisabledLayoutItem.Image")));
            this.layoutControl1.Controls.Add(this.printControl);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(429, 194, 250, 350);
            this.layoutControl1.Root = this.rootGroup;
            // 
            // printControl
            // 
            resources.ApplyResources(this.printControl, "printControl");
            this.printControl.Name = "printControl";
            // 
            // rootGroup
            // 
            resources.ApplyResources(this.rootGroup, "rootGroup");
            this.rootGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.rootGroup.GroupBordersVisible = false;
            this.rootGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.printingLayoutControlItem});
            this.rootGroup.Location = new System.Drawing.Point(0, 0);
            this.rootGroup.Name = "Root";
            this.rootGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.rootGroup.Size = new System.Drawing.Size(796, 378);
            this.rootGroup.TextVisible = false;
            // 
            // printingLayoutControlItem
            // 
            this.printingLayoutControlItem.Control = this.printControl;
            resources.ApplyResources(this.printingLayoutControlItem, "printingLayoutControlItem");
            this.printingLayoutControlItem.Location = new System.Drawing.Point(0, 0);
            this.printingLayoutControlItem.Name = "printingLayoutControlItem";
            this.printingLayoutControlItem.Size = new System.Drawing.Size(796, 378);
            this.printingLayoutControlItem.TextSize = new System.Drawing.Size(0, 0);
            this.printingLayoutControlItem.TextToControlDistance = 0;
            this.printingLayoutControlItem.TextVisible = false;
            // 
            // panelControl1
            // 
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Name = "panelControl1";
            // 
            // OpportunityReportView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "OpportunityReportView";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rootGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingLayoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraPrinting.Control.PrintControl printControl;
        protected PrintBarManager fPrintBarManager;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup rootGroup;
        private DevExpress.XtraLayout.LayoutControlItem printingLayoutControlItem;


    }
}
