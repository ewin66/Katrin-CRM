using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace Katrin.Win.MainModule.Views.SystemSetting
{
    public interface ISystemSettingListView
    {
        //void BindConfiguration(List<SystemSetting> configuration);
        //IEnumerable<SystemSetting> Configurations { get; }
        void Bind(List<object> configurations);
        DialogResult ShowDialog();
        GridView GridView { get; }
        void ShowMessage(string message);
        void Close();
        event EventHandler OK;
    }
}
