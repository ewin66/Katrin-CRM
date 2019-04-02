namespace Katrin.Win.MetadataManager
{
    partial class ViewColumnChooser
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
            this.fieldsPanel = new DevExpress.XtraEditors.GroupControl();
            this.fieldsListBox = new DevExpress.XtraEditors.ListBoxControl();
            this.okButton = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.moveAllLeftButton = new DevExpress.XtraEditors.SimpleButton();
            this.moveLeftButton = new DevExpress.XtraEditors.SimpleButton();
            this.moveAllRightButton = new DevExpress.XtraEditors.SimpleButton();
            this.cancelButton = new DevExpress.XtraEditors.SimpleButton();
            this.moveRightButton = new DevExpress.XtraEditors.SimpleButton();
            this.columnsPanel = new DevExpress.XtraEditors.GroupControl();
            this.columnsListBox = new DevExpress.XtraEditors.ListBoxControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsPanel)).BeginInit();
            this.fieldsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsListBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.columnsPanel)).BeginInit();
            this.columnsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.columnsListBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            this.SuspendLayout();
            // 
            // fieldsPanel
            // 
            this.fieldsPanel.Controls.Add(this.fieldsListBox);
            this.fieldsPanel.Location = new System.Drawing.Point(12, 12);
            this.fieldsPanel.Name = "fieldsPanel";
            this.fieldsPanel.Size = new System.Drawing.Size(219, 381);
            this.fieldsPanel.TabIndex = 0;
            this.fieldsPanel.Text = "Fields";
            // 
            // fieldsListBox
            // 
            this.fieldsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldsListBox.Location = new System.Drawing.Point(2, 22);
            this.fieldsListBox.Name = "fieldsListBox";
            this.fieldsListBox.Size = new System.Drawing.Size(215, 357);
            this.fieldsListBox.TabIndex = 0;
            this.fieldsListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fieldsListBox_MouseDown);
            this.fieldsListBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fieldsListBox_MouseMove);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(305, 397);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 22);
            this.okButton.StyleController = this.layoutControl1;
            this.okButton.TabIndex = 1;
            this.okButton.Text = "&OK";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.moveAllLeftButton);
            this.layoutControl1.Controls.Add(this.moveLeftButton);
            this.layoutControl1.Controls.Add(this.moveAllRightButton);
            this.layoutControl1.Controls.Add(this.cancelButton);
            this.layoutControl1.Controls.Add(this.moveRightButton);
            this.layoutControl1.Controls.Add(this.okButton);
            this.layoutControl1.Controls.Add(this.columnsPanel);
            this.layoutControl1.Controls.Add(this.fieldsPanel);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(717, 188, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(470, 431);
            this.layoutControl1.TabIndex = 7;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // moveAllLeftButton
            // 
            this.moveAllLeftButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.moveAllLeftButton.Location = new System.Drawing.Point(235, 231);
            this.moveAllLeftButton.Name = "moveAllLeftButton";
            this.moveAllLeftButton.Size = new System.Drawing.Size(33, 22);
            this.moveAllLeftButton.StyleController = this.layoutControl1;
            this.moveAllLeftButton.TabIndex = 5;
            this.moveAllLeftButton.Text = "<<";
            this.moveAllLeftButton.Click += new System.EventHandler(this.moveAllLeftButton_Click);
            // 
            // moveLeftButton
            // 
            this.moveLeftButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.moveLeftButton.Location = new System.Drawing.Point(235, 179);
            this.moveLeftButton.Name = "moveLeftButton";
            this.moveLeftButton.Size = new System.Drawing.Size(33, 22);
            this.moveLeftButton.StyleController = this.layoutControl1;
            this.moveLeftButton.TabIndex = 3;
            this.moveLeftButton.Text = "<";
            this.moveLeftButton.Click += new System.EventHandler(this.moveLeftButton_Click);
            // 
            // moveAllRightButton
            // 
            this.moveAllRightButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.moveAllRightButton.Location = new System.Drawing.Point(235, 205);
            this.moveAllRightButton.Name = "moveAllRightButton";
            this.moveAllRightButton.Size = new System.Drawing.Size(33, 22);
            this.moveAllRightButton.StyleController = this.layoutControl1;
            this.moveAllRightButton.TabIndex = 4;
            this.moveAllRightButton.Text = ">>";
            this.moveAllRightButton.Click += new System.EventHandler(this.moveAllRightButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(384, 397);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(74, 22);
            this.cancelButton.StyleController = this.layoutControl1;
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // moveRightButton
            // 
            this.moveRightButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.moveRightButton.Location = new System.Drawing.Point(235, 153);
            this.moveRightButton.Name = "moveRightButton";
            this.moveRightButton.Size = new System.Drawing.Size(33, 22);
            this.moveRightButton.StyleController = this.layoutControl1;
            this.moveRightButton.TabIndex = 2;
            this.moveRightButton.Text = ">";
            this.moveRightButton.Click += new System.EventHandler(this.moveRightButton_Click);
            // 
            // columnsPanel
            // 
            this.columnsPanel.Controls.Add(this.columnsListBox);
            this.columnsPanel.Location = new System.Drawing.Point(272, 12);
            this.columnsPanel.Name = "columnsPanel";
            this.columnsPanel.Size = new System.Drawing.Size(186, 381);
            this.columnsPanel.TabIndex = 0;
            this.columnsPanel.Text = "Columns";
            // 
            // columnsListBox
            // 
            this.columnsListBox.AllowDrop = true;
            this.columnsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.columnsListBox.Location = new System.Drawing.Point(2, 22);
            this.columnsListBox.Name = "columnsListBox";
            this.columnsListBox.Size = new System.Drawing.Size(182, 357);
            this.columnsListBox.TabIndex = 0;
            this.columnsListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.columnsListBox_DragDrop);
            this.columnsListBox.DragOver += new System.Windows.Forms.DragEventHandler(this.columnsListBox_DragOver);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(470, 431);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.fieldsPanel;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(223, 385);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.columnsPanel;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(260, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(190, 385);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.okButton;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(293, 385);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(79, 26);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(79, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(79, 26);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.cancelButton;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(372, 385);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(78, 26);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(78, 26);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(78, 26);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 385);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(293, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.moveRightButton;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(223, 141);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(37, 26);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(37, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(37, 26);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(223, 245);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(37, 140);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(223, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(37, 141);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.moveLeftButton;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(223, 167);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(37, 26);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(37, 26);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(37, 26);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.moveAllRightButton;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(223, 193);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(37, 26);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(37, 26);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(37, 26);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.moveAllLeftButton;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new System.Drawing.Point(223, 219);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(37, 26);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(37, 26);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(37, 26);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Text = "layoutControlItem9";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextToControlDistance = 0;
            this.layoutControlItem9.TextVisible = false;
            // 
            // ViewColumnChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ViewColumnChooser";
            this.Size = new System.Drawing.Size(470, 431);
            ((System.ComponentModel.ISupportInitialize)(this.fieldsPanel)).EndInit();
            this.fieldsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fieldsListBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.columnsPanel)).EndInit();
            this.columnsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.columnsListBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl fieldsPanel;
        private DevExpress.XtraEditors.ListBoxControl fieldsListBox;
        private DevExpress.XtraEditors.SimpleButton okButton;
        private DevExpress.XtraEditors.SimpleButton cancelButton;
        private DevExpress.XtraEditors.GroupControl columnsPanel;
        private DevExpress.XtraEditors.ListBoxControl columnsListBox;
        private DevExpress.XtraEditors.SimpleButton moveRightButton;
        private DevExpress.XtraEditors.SimpleButton moveLeftButton;
        private DevExpress.XtraEditors.SimpleButton moveAllRightButton;
        private DevExpress.XtraEditors.SimpleButton moveAllLeftButton;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
    }
}
