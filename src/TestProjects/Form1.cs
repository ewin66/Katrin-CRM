
using Katrin.AppFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProjects
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ICSharpCode.Core.Services.ServiceManager.Instance = new Katrin.AppFramework.WinForms.Services.ServiceManager();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ICSharpCode.Core.MessageService.ShowMessage("????????", "Test");
            ICSharpCode.Core.MessageService.ShowError("??????????");
            try
            {
                int a = 1, b = 0;
                a = a / b;
            }
            catch (Exception ex)
            {

                ICSharpCode.Core.MessageService.ShowException(ex, "????");
            }

            ICSharpCode.Core.MessageService.ShowWarning("??????????");
            bool yes = ICSharpCode.Core.MessageService.AskQuestion("???????", "???");
            if (yes)
            {
                ICSharpCode.Core.MessageService.ShowMessage("????", "Test");
            }
            else
            {
                ICSharpCode.Core.MessageService.ShowMessage("????!", "Test");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ICSharpCode.Core.LoggingService.Debug("Debug:dsjaflsdjfl");
            ICSharpCode.Core.LoggingService.DebugFormatted("debugformat{0}--{1}", "aaa", "bbb");

            ICSharpCode.Core.LoggingService.Error("error:dsjaflsdjfl");

            ICSharpCode.Core.LoggingService.Fatal("fatal:dsjaflsdjfl");
        }
    }
}
