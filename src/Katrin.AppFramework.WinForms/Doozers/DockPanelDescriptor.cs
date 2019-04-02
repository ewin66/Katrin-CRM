using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;

namespace Katrin.AppFramework.WinForms.Doozers
{
    public class DockPanelDescriptor
    {
        public object Caller { get; private set; }
        public Codon Codon { get; private set; }

        public string ControllerId
        {
            get
            {
                return Codon.Properties["controller"];
            }
        }

        public string ActionName
        {
            get
            {
                return Codon.Properties["action"];
            }
        }

        public DockPanelDescriptor(object caller, Codon codon)
        {
            Caller = caller;
            Codon = codon;
        }

        //public XtraForm CreateUserControl()
        //{
        //    var userControlClassName = Codon.Properties["class"];
        //    var userControlType = Codon.AddIn.FindType(userControlClassName);
        //    if (!typeof(XtraForm).IsAssignableFrom(userControlType))
        //    {
        //        var message = "The class {0} doesn't implement XtraUserControl, please check the class property in your addin config file";
        //        throw new Exception(string.Format(message, userControlType.FullName));
        //    }
        //    return (XtraForm)Activator.CreateInstance(userControlType);
        //}
    }
}
