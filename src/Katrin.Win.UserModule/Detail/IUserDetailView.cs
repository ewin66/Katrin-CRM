using System;
using System.Collections.Generic;
using Katrin.AppFramework.WinForms.ViewInterface;
using System.Collections;
using Katrin.AppFramework.WinForms.Messages;

namespace Katrin.Win.UserModule.Detail
{
    public interface IUserDetailView : IObjectDetailView
    {
        ArrayList SelectedRoles { get; }
        bool HasSave { get; set; }
        void ClearPassword();
        void BindRole(List<Guid> selectedRoles);
        bool ValidateData(EntityDetailWorkingMode WorkingMode);
        void SetUserNameFocused();
    }
}
