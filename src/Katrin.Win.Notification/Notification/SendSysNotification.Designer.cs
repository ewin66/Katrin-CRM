using System;
namespace Katrin.Win.Common.Notification
{
    partial class SendSysNotification
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
            //GC.SuppressFinalize(this);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendSysNotification));
            this.sysMsgLayout = new DevExpress.XtraLayout.LayoutControl();
            this.ReceiverPopupContainerEdit = new DevExpress.XtraEditors.PopupContainerEdit();
            this.cancelButton = new DevExpress.XtraEditors.SimpleButton();
            this.bodyEdit = new DevExpress.XtraEditors.MemoEdit();
            this.EntityBindingSource = new System.Windows.Forms.BindingSource();
            this.saveButton = new DevExpress.XtraEditors.SimpleButton();
            this.subjectEdit = new DevExpress.XtraEditors.TextEdit();
            this.sysMsgLayoutGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itemForSubject = new DevExpress.XtraLayout.LayoutControlItem();
            this.itemforBody = new DevExpress.XtraLayout.LayoutControlItem();
            this.itemForSave = new DevExpress.XtraLayout.LayoutControlItem();
            this.itemforCancel = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ItemForReceiver = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            ((System.ComponentModel.ISupportInitialize)(this.sysMsgLayout)).BeginInit();
            this.sysMsgLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiverPopupContainerEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodyEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysMsgLayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForSubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemforBody)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemforCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForReceiver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // sysMsgLayout
            // 
            this.sysMsgLayout.Controls.Add(this.ReceiverPopupContainerEdit);
            this.sysMsgLayout.Controls.Add(this.cancelButton);
            this.sysMsgLayout.Controls.Add(this.bodyEdit);
            this.sysMsgLayout.Controls.Add(this.saveButton);
            this.sysMsgLayout.Controls.Add(this.subjectEdit);
            resources.ApplyResources(this.sysMsgLayout, "sysMsgLayout");
            this.sysMsgLayout.Name = "sysMsgLayout";
            this.sysMsgLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(825, 117, 436, 350);
            this.sysMsgLayout.Root = this.sysMsgLayoutGroup;
            // 
            // ReceiverPopupContainerEdit
            // 
            resources.ApplyResources(this.ReceiverPopupContainerEdit, "ReceiverPopupContainerEdit");
            this.ReceiverPopupContainerEdit.Name = "ReceiverPopupContainerEdit";
            this.ReceiverPopupContainerEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ReceiverPopupContainerEdit.Properties.Buttons"))))});
            this.ReceiverPopupContainerEdit.StyleController = this.sysMsgLayout;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.StyleController = this.sysMsgLayout;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // bodyEdit
            // 
            this.bodyEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Body", true));
            resources.ApplyResources(this.bodyEdit, "bodyEdit");
            this.bodyEdit.Name = "bodyEdit";
            this.bodyEdit.StyleController = this.sysMsgLayout;
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.StyleController = this.sysMsgLayout;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // subjectEdit
            // 
            this.subjectEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.EntityBindingSource, "Subject", true));
            resources.ApplyResources(this.subjectEdit, "subjectEdit");
            this.subjectEdit.Name = "subjectEdit";
            this.subjectEdit.StyleController = this.sysMsgLayout;
            // 
            // sysMsgLayoutGroup
            // 
            resources.ApplyResources(this.sysMsgLayoutGroup, "sysMsgLayoutGroup");
            this.sysMsgLayoutGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.sysMsgLayoutGroup.GroupBordersVisible = false;
            this.sysMsgLayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itemForSubject,
            this.itemforBody,
            this.itemForSave,
            this.itemforCancel,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.ItemForReceiver});
            this.sysMsgLayoutGroup.Location = new System.Drawing.Point(0, 0);
            this.sysMsgLayoutGroup.Name = "Root";
            this.sysMsgLayoutGroup.Size = new System.Drawing.Size(517, 286);
            this.sysMsgLayoutGroup.TextVisible = false;
            // 
            // itemForSubject
            // 
            this.itemForSubject.Control = this.subjectEdit;
            resources.ApplyResources(this.itemForSubject, "itemForSubject");
            this.itemForSubject.Location = new System.Drawing.Point(0, 24);
            this.itemForSubject.Name = "itemForSubject";
            this.itemForSubject.Size = new System.Drawing.Size(497, 24);
            this.itemForSubject.TextSize = new System.Drawing.Size(46, 14);
            // 
            // itemforBody
            // 
            this.itemforBody.Control = this.bodyEdit;
            resources.ApplyResources(this.itemforBody, "itemforBody");
            this.itemforBody.Location = new System.Drawing.Point(0, 48);
            this.itemforBody.Name = "itemforBody";
            this.itemforBody.Size = new System.Drawing.Size(497, 192);
            this.itemforBody.TextSize = new System.Drawing.Size(46, 14);
            // 
            // itemForSave
            // 
            this.itemForSave.Control = this.saveButton;
            resources.ApplyResources(this.itemForSave, "itemForSave");
            this.itemForSave.Location = new System.Drawing.Point(299, 240);
            this.itemForSave.MaxSize = new System.Drawing.Size(89, 26);
            this.itemForSave.MinSize = new System.Drawing.Size(89, 26);
            this.itemForSave.Name = "itemForSave";
            this.itemForSave.Size = new System.Drawing.Size(89, 26);
            this.itemForSave.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.itemForSave.TextSize = new System.Drawing.Size(0, 0);
            this.itemForSave.TextToControlDistance = 0;
            this.itemForSave.TextVisible = false;
            // 
            // itemforCancel
            // 
            this.itemforCancel.Control = this.cancelButton;
            resources.ApplyResources(this.itemforCancel, "itemforCancel");
            this.itemforCancel.Location = new System.Drawing.Point(398, 240);
            this.itemforCancel.MaxSize = new System.Drawing.Size(89, 26);
            this.itemforCancel.MinSize = new System.Drawing.Size(89, 26);
            this.itemforCancel.Name = "itemforCancel";
            this.itemforCancel.Size = new System.Drawing.Size(89, 26);
            this.itemforCancel.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.itemforCancel.TextSize = new System.Drawing.Size(0, 0);
            this.itemforCancel.TextToControlDistance = 0;
            this.itemforCancel.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem2, "emptySpaceItem2");
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 240);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(299, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem3, "emptySpaceItem3");
            this.emptySpaceItem3.Location = new System.Drawing.Point(388, 240);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(10, 26);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem4, "emptySpaceItem4");
            this.emptySpaceItem4.Location = new System.Drawing.Point(487, 240);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(10, 26);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ItemForReceiver
            // 
            this.ItemForReceiver.Control = this.ReceiverPopupContainerEdit;
            resources.ApplyResources(this.ItemForReceiver, "ItemForReceiver");
            this.ItemForReceiver.Location = new System.Drawing.Point(0, 0);
            this.ItemForReceiver.Name = "ItemForReceiver";
            this.ItemForReceiver.Size = new System.Drawing.Size(497, 24);
            this.ItemForReceiver.TextSize = new System.Drawing.Size(46, 14);
            // 
            // SendSysNotification
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sysMsgLayout);
            this.Name = "SendSysNotification";
            this.Load += new System.EventHandler(this.SendSysNotification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sysMsgLayout)).EndInit();
            this.sysMsgLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ReceiverPopupContainerEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodyEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysMsgLayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForSubject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemforBody)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemforCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForReceiver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl sysMsgLayout;
        private DevExpress.XtraLayout.LayoutControlGroup sysMsgLayoutGroup;
        private DevExpress.XtraEditors.TextEdit subjectEdit;
        private DevExpress.XtraLayout.LayoutControlItem itemForSubject;
        private DevExpress.XtraEditors.MemoEdit bodyEdit;
        private DevExpress.XtraLayout.LayoutControlItem itemforBody;
        private DevExpress.XtraEditors.SimpleButton cancelButton;
        private DevExpress.XtraEditors.SimpleButton saveButton;
        private DevExpress.XtraLayout.LayoutControlItem itemForSave;
        private DevExpress.XtraLayout.LayoutControlItem itemforCancel;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        protected System.Windows.Forms.BindingSource EntityBindingSource;
        private DevExpress.XtraEditors.PopupContainerEdit ReceiverPopupContainerEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForReceiver;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider;
    }
}
