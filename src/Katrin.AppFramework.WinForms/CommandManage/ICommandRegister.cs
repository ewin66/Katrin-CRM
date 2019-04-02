using DevExpress.XtraBars;
using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.CommandManage
{
   public interface ICommandRegister
    {
       /// <summary>
       /// rigister ribbon command in addin file.
       /// </summary>
       /// <param name="item"></param>
       /// <param name="cmdPath"></param>
       /// <param name="action"></param>
       /// <returns></returns>
        bool RegisterCommand(BarItem item, string cmdPath, ICommand action,IEnumerable<ICondition> conditions);
       /// <summary>
       /// Rigister Ribbon dynamic command
       /// </summary>
       /// <param name="item"></param>
       /// <param name="cmdPath"></param>
       /// <param name="action"></param>
       /// <param name="dynamicGroupName"></param>
       /// <returns></returns>
        bool RegisterCommand(BarItem item,string cmdId, string cmdPath, ICommand action,string dynamicGroupName);
        object owner { get; }

        BarItem GetBarItem(string cmdId);
        List<BarItem> GetDynamicBarItems(string groupId);

      
    }
}
