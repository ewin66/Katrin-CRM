using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.MVC.Data;
using Katrin.AppFramework.WinForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework;
using Katrin.AppFramework.WinForms.Grid;
using Katrin.AppFramework.WinForms;
using ICSharpCode.Core;


namespace Katrin.Win.RoleModule
{
    public class RoleController : ListController
    {
        public override string ObjectName
        {
            get
            {
                return "Role";
            }
        }

        protected override string RibbonPath
        {
            get { return "/Role/List/Ribbon"; }
        }
    }
}
