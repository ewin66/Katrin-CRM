using System;
using System.Collections.Generic;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.MetadataServiceReference;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.Win.DetailViewModule;

namespace Katrin.Win.AttendanceModule.Detail
{
    public partial class AttendanceDetailView : DetailView, IAttendanceDetailView
    {
        public EntityDetailWorkingMode WorkMode
        {
            get;
            set;
        }

        public AttendanceDetailView()
        {
            InitializeComponent();
            RecordOndateEdit.Properties.NullText = DateTime.Today.ToString("yyy/M/d");
        }

        public override void InitEditors(Entity entity)
        {
            base.InitEditors(entity);
            bool maskSelect = WorkMode == EntityDetailWorkingMode.Add;
            RecordPopupContainerEdit.InitEdit("User", "Department", maskSelect);
            if (maskSelect)
            {
                RecordPopupContainerEdit.DataBindings.Clear();
            }
            AttendanceTypeLookUpEdit.BindPickList(entity);
            AttendanceUnitCodeLookupEdit.BindPickList(entity);
        }

        public List<Guid> GetRecordPersonList()
        {
            return RecordPopupContainerEdit.GetSelection();
        }

        public override void InitValidation()
        {
            SetValidationRule(AttendanceTypeLookUpEdit, ValidationRules.IsNotBlankRule(ItemForAttendanceType.Text));
            SetValidationRule(RecordPopupContainerEdit, ValidationRules.IsNotBlankRule(ItemForRecord.Text));
            SetValidationRule(AttendanceUnitCodeLookupEdit, ValidationRules.IsGuidNotBlankRule(ItemForAttendanceUnitCode.Text));
        }
    }
}
