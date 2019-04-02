using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraBars;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Workspaces;

namespace Katrin.AppFramework.WinForms.CommandManage
{
    /// <summary>
    /// UICommand Interface.
    /// author:hecq
    /// date:2012-11-16
    /// </summary>
    public interface IUICommand:IDisposable
    {
        
        string CommandId { get; }
        string CheckForViewId { get; }
        bool CanCheck { get; }
        bool Checked { get; set; }
        bool Visualble { get; set; }
        bool Enable { get; set; }
        bool IsRunTimeContainer { get; }
        IList<ICondition> Conditions { get;}
        BarItem BarItem { get; }
        CommandSources Source {get;}
       
        string controllerId { get; set; }

        bool Excute();
        void CheckConditions(IController controller,IWorkspace1 workSpace);
        void HookCommand(BarItem barItem, ICommand actionCommand, IEnumerable<ICondition> conditions);
        void AddConditon(ICondition condition);

        string GroupName { get; }
        string RibbonPath { get; }
        void OverrideAction(ICommand action);

    }

   

  
}
