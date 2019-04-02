using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using System.Windows.Forms;
namespace Katrin.Win.MainModule.Views.Opportunity
{
    public partial class OpportunityLossReason : XtraForm
    {
        public OpportunityLossReason()
        {
            InitializeComponent();
            
        }

        public string LossReasion()
        {
            return ReasionTextEdit.Text;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ReasionTextEdit.Text == "")
            {
                XtraMessageBox.Show(this, Properties.Resources.ReasonNullTip,
                    Properties.Resources.Katrin, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information, 
                    MessageBoxDefaultButton.Button1);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
            //lossReason = ReasionTextEdit.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
