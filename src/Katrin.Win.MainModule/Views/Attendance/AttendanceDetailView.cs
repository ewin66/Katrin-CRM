using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Katrin.Win.Common.Core;
using Microsoft.Practices.ObjectBuilder;
using Katrin.Win.Common.MetadataServiceReference;
using Katrin.Win.Common.Controls;
namespace Katrin.Win.MainModule.Views.Attendance
{
    public partial class AttendanceDetailView : AbstractDetailView, IAttendanceDetailView
    {
        private AttendanceDetailPresenter _presenter;
        public EntityDetailWorkingMode WorkMode
        {
            get;
            set;
        }
        [CreateNew]
        public AttendanceDetailPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = this;
            }
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
