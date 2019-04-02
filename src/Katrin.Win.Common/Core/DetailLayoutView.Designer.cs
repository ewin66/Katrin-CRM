namespace Katrin.Win.Common.Core
{
    partial class DetailLayoutView
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
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonWindowSmartPartInfo = new CABDevExpress.SmartPartInfos.RibbonWindowSmartPartInfo();
            this.infoProvider = new Microsoft.Practices.CompositeUI.SmartParts.SmartPartInfoProvider();
            this.detailContentTabWorkspace = new CABDevExpress.Workspaces.XtraTabWorkspace();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailContentTabWorkspace)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 1;
            this.ribbon.Name = "ribbon";
            this.ribbon.Size = new System.Drawing.Size(794, 48);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 515);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(794, 27);
            // 
            // ribbonWindowSmartPartInfo
            // 
            this.ribbonWindowSmartPartInfo.Description = "";
            this.ribbonWindowSmartPartInfo.Location = new System.Drawing.Point(0, 0);
            this.ribbonWindowSmartPartInfo.Ribbon = null;
            this.ribbonWindowSmartPartInfo.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ribbonWindowSmartPartInfo.StatusBar = null;
            this.ribbonWindowSmartPartInfo.Title = "";
            this.ribbonWindowSmartPartInfo.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.infoProvider.Items.Add(this.ribbonWindowSmartPartInfo);
            // 
            // detailContentTabWorkspace
            // 
            this.detailContentTabWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailContentTabWorkspace.Location = new System.Drawing.Point(0, 48);
            this.detailContentTabWorkspace.Name = "detailContentTabWorkspace";
            this.detailContentTabWorkspace.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.detailContentTabWorkspace.Size = new System.Drawing.Size(794, 467);
            this.detailContentTabWorkspace.TabIndex = 5;
            // 
            // DetailLayoutView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.detailContentTabWorkspace);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "DetailLayoutView";
            this.Size = new System.Drawing.Size(794, 542);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailContentTabWorkspace)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private CABDevExpress.SmartPartInfos.RibbonWindowSmartPartInfo ribbonWindowSmartPartInfo;
        private CABDevExpress.Workspaces.XtraTabWorkspace detailContentTabWorkspace;
        private Microsoft.Practices.CompositeUI.SmartParts.SmartPartInfoProvider infoProvider;
    }
}
