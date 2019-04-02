using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;

namespace Katrin.AppFramework.WinForms.Controls
{
    public class DropDownDateEdit : DateEdit
    {
        bool _isPopupOpen;
        public DropDownDateEdit()
        {
            this.MouseUp += (sender, e) =>
            {
                if (_isPopupOpen && !this.IsPopupOpen)
                {
                    _isPopupOpen = false;
                    this.ClosePopup();
                }
                else
                {
                    _isPopupOpen = true;
                    this.ShowPopup();
                }
            };
            this.Closed += (sender, e) =>
            {
                _isPopupOpen = false;
            };
            this.Popup += (sender, e) =>
            {
                _isPopupOpen = true;
            };
        }
    }
}
