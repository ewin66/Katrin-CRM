
namespace Katrin.AppFramework.WinForms.Workspaces
{
    partial class RibbonFormWorkspace
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RibbonFormWorkspace));
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.itemProgress = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemMarqueeProgressBar2 = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
            this.ribbon = new Katrin.AppFramework.WinForms.Controls.RibbonControlEx();
            this.repositoryItemMarqueeProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.itemProgress);
            resources.ApplyResources(this.ribbonStatusBar, "ribbonStatusBar");
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            // 
            // itemProgress
            // 
            this.itemProgress.Edit = this.repositoryItemMarqueeProgressBar2;
            this.itemProgress.Id = 2;
            this.itemProgress.Name = "itemProgress";
            this.itemProgress.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            resources.ApplyResources(this.itemProgress, "itemProgress");
            // 
            // repositoryItemMarqueeProgressBar2
            // 
            this.repositoryItemMarqueeProgressBar2.Name = "repositoryItemMarqueeProgressBar2";
            // 
            // ribbon
            // 
            this.ribbon.AutoSizeItems = true;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.itemProgress});
            resources.ApplyResources(this.ribbon, "ribbon");
            this.ribbon.MaxItemId = 3;
            this.ribbon.Name = "ribbon";
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMarqueeProgressBar1,
            this.repositoryItemMarqueeProgressBar2});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // repositoryItemMarqueeProgressBar1
            // 
            this.repositoryItemMarqueeProgressBar1.Name = "repositoryItemMarqueeProgressBar1";
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "Katrin.AppFramework.WinForms.Controls.RibbonControlEx"});
            // 
            // RibbonFormWorkspace
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbon);
            this.Controls.Add(this.ribbonStatusBar);
            this.KeyPreview = true;
            this.Name = "RibbonFormWorkspace";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RibbonFormWorkspace_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RibbonFormWorkspace_FormClosed);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RibbonFormWorkspace_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private Katrin.AppFramework.WinForms.Controls.RibbonControlEx ribbon;
        private DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar repositoryItemMarqueeProgressBar1;
        private DevExpress.XtraBars.BarEditItem itemProgress;
        private DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar repositoryItemMarqueeProgressBar2;
    }
}
