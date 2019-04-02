using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Accessibility;
using DevExpress.Data.WcfLinq;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using Katrin.Win.Infrastructure.Services;
using Katrin.Win.Common.MetadataServiceReference;
using System.Reflection;
using System.IO;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.Data.Filtering;

namespace Katrin.Win.Common.Controls
{
    [UserRepositoryItem("RegisterWcfRepositoryItemSearchLookUpEdit")]
    public class WcfRepositoryItemSearchLookUpEdit : RepositoryItemSearchLookUpEdit
    {
        //The static constructor which calls the registration method
        static WcfRepositoryItemSearchLookUpEdit() { RegisterWcfRepositoryItemSearchLookUpEdit(); }


        //Initialize new properties
        public WcfRepositoryItemSearchLookUpEdit()
        {
            //this.Buttons.Add(new EditorButton(ButtonPredefines.Combo));
        }

        private string _entityName;
        internal string EntityName
        {
            get
            {
                return _entityName;
            }
            set
            {
                _entityName = value;
            }
        }

        //The unique name for the custom editor
        public const string CustomEditName = "WcfSearchLookUpEdit";

        //Return the unique name
        public override string EditorTypeName { get { return CustomEditName; } }

        //Register the editor
        public static void RegisterWcfRepositoryItemSearchLookUpEdit()
        {
            if (EditorRegistrationInfo.Default.Editors.Contains(CustomEditName))
                return;
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName,
                                                                           typeof (WcfSearchLookUpEdit),
                                                                           typeof (WcfRepositoryItemSearchLookUpEdit),
                                                                           typeof (SearchLookUpEditBaseViewInfo),
                                                                           new ButtonEditPainter(),
                                                                           true, null,
                                                                           typeof (PopupEditAccessible)));
        }

        public void ForeceActiveGridDataSource()
        {
            //base.ActivateGridDataSource();
        }

        public override string GetDisplayText(DevExpress.Utils.FormatInfo format, object editValue)
        {
            if (string.IsNullOrEmpty(EntityName)) return base.GetDisplayText(format, editValue);
            if (DataSource == null && !IsNullValue(editValue) && !IsNullOrEmptyGuiId(editValue))
            {
                var serviceContext = new DynamicDataServiceContext();
                var displayValue = serviceContext.GetPropertyValue(EntityName, editValue, DisplayMember);
                if (displayValue != null) return displayValue.ToString();
                return GetNullEditText();
            }
            if (IsNullValue(editValue)) return base.GetDisplayText(format, editValue);
            object res = GetDisplayTextByKeyValueCore(editValue);
            if (BaseEdit.IsNotLoadedValue(res))
            {
                //if (OwnerEdit != null) OwnerEdit.requireUpdateDisplayText = true;
                return string.Empty;
            }
            if (res == null) return string.Empty;
            return res.ToString();
        }

        private bool IsNullOrEmptyGuiId(object editValue)
        {
            if (editValue is Guid)
            {
                return ((Guid)editValue) == Guid.Empty;
            }
            return false;
        }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                var source = item as WcfRepositoryItemSearchLookUpEdit;
                if (source == null) return;
                EntityName = source.EntityName;
            }
            finally
            {
                EndUpdate();
            }
        }
    }


    public class WcfSearchLookUpEdit : SearchLookUpEdit
    {
        //The static constructor which calls the registration method
        static WcfSearchLookUpEdit() { WcfRepositoryItemSearchLookUpEdit.RegisterWcfRepositoryItemSearchLookUpEdit(); }
        WaitDialogForm _waitForm;
        //Initialize the new instance
        public WcfSearchLookUpEdit()
        {
            this.QueryPopUp += WcfSearchLookUpEdit_QueryPopUp;
            //this.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Combo));
        }

        void WcfSearchLookUpEdit_QueryPopUp(object sender, CancelEventArgs e)
        {
            if (Properties.DataSource == null)
            {
                e.Cancel = true;
                LoadData();
                _waitForm = new WaitDialogForm();
                _waitForm.Show();
            }
        }

        public void Bind(Entity entity)
        {
            if (entity == null) return;
            if (this.DataBindings.Count == 0) return;

            var binding = this.DataBindings[0];

            string attributeName = binding.BindingMemberInfo.BindingMember;

            var attribute = entity.Attributes.FirstOrDefault(a => a.PhysicalName.Equals(attributeName));
            var lookupValue = attribute.AttributeLookupValues.First();
            var lookupValueEntity = lookupValue.Entity;

            Properties.View.MouseMove += View_MouseMove;
            Properties.BeginInit();

            Properties.EntityName = lookupValueEntity.PhysicalName;

            var displayAttribute = lookupValueEntity.Attributes.First(a => a.AttributeId == lookupValue.DisplayEntityAttributeId);
            Properties.DisplayMember = displayAttribute.PhysicalName;

            var primaryKeyAttribute = lookupValueEntity.Attributes.Single(a => a.IsPKAttribute.HasValue && a.IsPKAttribute.Value);
            Properties.ValueMember = primaryKeyAttribute.PhysicalName;
            Properties.NullText = string.Empty;
            Properties.AllowNullInput = DefaultBoolean.True;
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            Properties.ShowFooter = false;
            Properties.View.LoadDefaultLayout(Properties.EntityName);
            Properties.View.InitColumns(Properties.EntityName);

            Properties.EndInit();
        }

        void View_MouseMove(object sender, MouseEventArgs e)
        {
            DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
        }

        public void ReloadData(CriteriaOperator commonFilter)
        {
            Properties.BindDataAsync(Properties.EntityName, null, commonFilter);
        }

        void LoadData()
        {
            if (Properties.DataSource != null) return;
            Properties.BindDataAsync(Properties.EntityName, () =>
            {
                _waitForm.Close();
                this.ShowPopup();
            }, null);
        }

        //Return the unique name
        public override string EditorTypeName
        {
            get
            {
                return WcfRepositoryItemSearchLookUpEdit.CustomEditName;
            }
        }

        //Override the Properties property
        //Simply type-cast the object to the custom repository item type
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new WcfRepositoryItemSearchLookUpEdit Properties
        {
            get { return base.Properties as WcfRepositoryItemSearchLookUpEdit; }
        }
        
    }
}
