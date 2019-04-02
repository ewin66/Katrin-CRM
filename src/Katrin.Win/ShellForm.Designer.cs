namespace Katrin.Win
{
    partial class ShellForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShellForm));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.pmAppMain = new DevExpress.XtraBars.Ribbon.ApplicationMenu();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.contextWorkspace = new Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace();
            this.navBarWorkspace = new CABDevExpress.Workspaces.XtraNavBarWorkspace();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmAppMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarWorkspace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonDropDownControl = this.pmAppMain;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 56;
            this.ribbon.Name = "ribbon";
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbon.Size = new System.Drawing.Size(701, 50);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.TransparentEditors = true;
            // 
            // pmAppMain
            // 
            this.pmAppMain.Name = "pmAppMain";
            this.pmAppMain.Ribbon = this.ribbon;
            this.pmAppMain.ShowRightPane = true;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 414);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(701, 31);
            // 
            // contextWorkspace
            // 
            this.contextWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contextWorkspace.Location = new System.Drawing.Point(0, 0);
            this.contextWorkspace.Name = "contextWorkspace";
            this.contextWorkspace.Size = new System.Drawing.Size(541, 364);
            this.contextWorkspace.TabIndex = 4;
            // 
            // navBarWorkspace
            // 
            this.navBarWorkspace.ActiveGroup = null;
            this.navBarWorkspace.AllowSelectedLink = true;
            this.navBarWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarWorkspace.Location = new System.Drawing.Point(0, 0);
            this.navBarWorkspace.Name = "navBarWorkspace";
            this.navBarWorkspace.NavigationPaneMaxVisibleGroups = 1;
            this.navBarWorkspace.OptionsNavPane.ExpandedWidth = 155;
            this.navBarWorkspace.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarWorkspace.Size = new System.Drawing.Size(155, 364);
            this.navBarWorkspace.TabIndex = 7;
            this.navBarWorkspace.Text = "xtraNavBarWorkspace1";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 50);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.navBarWorkspace);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.contextWorkspace);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(701, 364);
            this.splitContainerControl1.SplitterPosition = 155;
            this.splitContainerControl1.TabIndex = 14;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // ShellForm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 445);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShellForm";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "ShellForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmAppMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarWorkspace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace contextWorkspace;
        private CABDevExpress.Workspaces.XtraNavBarWorkspace navBarWorkspace;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu pmAppMain;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
    }
}
