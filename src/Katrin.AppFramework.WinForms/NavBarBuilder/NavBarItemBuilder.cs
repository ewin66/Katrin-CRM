using Katrin.AppFramework.Parts;
using DevExpress.XtraNavBar;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.NavBarBuilder
{
    public class NavBarItemBuilder : AbstractPartBuilder
    {
        public override object Build(ICSharpCode.Core.Codon codon, object caller, IEnumerable<ICSharpCode.Core.ICondition> conditions)
        {
            var label = codon.Properties["label"] ?? codon.Id;
            var command = (ICommand)codon.AddIn.CreateObject(codon.Properties["class"]);
            command.Owner = caller;
            var caption = StringParser.Parse(label);
            var item = new ModuleNavBarItem(caption, command);

            SetItemImage(item, codon);
            
            return item;
        }

        private void SetItemImage(NavBarItem barItem, ICSharpCode.Core.Codon codon)
        {
            string iconName = codon.Properties["icon"];
            if (string.IsNullOrEmpty(iconName)) return;
            var icon = WinFormsResourceService.GetIcon(iconName.ToLower());
            if (icon == null) return;
            barItem.LargeImage = icon.ToBitmap();
            barItem.SmallImage = icon.ToBitmap();
        }
    }

    public class ModuleNavBarItem:NavBarItem
    {
        private ICommand _command;
        public ModuleNavBarItem(string caption, ICommand command)
        {
            this.Caption = caption;
            _command = command;
        }

        protected override void RaiseLinkClicked(NavBarItemLink link)
        {
            _command.Run();
            base.RaiseLinkClicked(link);
        }

        /// <summary>
        /// ModuleName.
        /// </summary>
        public string ModuleName { get; set; }
    }
}
