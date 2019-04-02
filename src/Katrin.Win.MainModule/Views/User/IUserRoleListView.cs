using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Katrin.Win.MainModule.Views.User
{
    public interface IUserRoleListView
    {
        void BindRole(List<RoleModel> role);
        void ShowMessage(string message);
        void Close();
        void PostEditors();
        event EventHandler OK;
        event EventHandler OnClose;
        List<Guid> SelectedRoles { get; }
        void ShowView();
    }
}
