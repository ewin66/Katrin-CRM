using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using ICSharpCode.Core;
namespace Katrin.Win.OpportunityModule
{
    public partial class OpportunityLossReason : XtraForm
    {
        public OpportunityLossReason()
        {
            InitializeComponent();
            
        }

        public string LossReasion
        {
            get
            {
                return ReasionTextEdit.Text;
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ReasionTextEdit.Text == "")
            {
                string caption = ResourceService.GetString("ReasonNullTip");
                string text = ResourceService.GetString("Katrin");

                XtraMessageBox.Show(this, 
                    caption,
                    text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
