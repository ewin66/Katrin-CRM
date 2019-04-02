using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using Katrin.AppFramework.WinForms.ViewInterface;


namespace Katrin.Win.InvoiceModule
{
    public interface IInvoiceDetailView : IObjectDetailView
    {
        void BindContract(List<Guid> selectedContracts);
        ArrayList SelectedContracts { get; }
        event EventHandler OnStatusCodeChanged;
    }
}
