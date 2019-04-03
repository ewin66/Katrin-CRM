using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms
{
    /// <summary>
    /// Ribbon Buider Factory
    /// Get buider by ribbonBuider config in Shell.addin or module.addin
    /// date:2012-10-23
    /// </summary>
    static class RibbonBuilderManager
    {
        static Dictionary<string, IPartBuilder> _Builders = null;

        static void InitBuilders()
        {
            _Builders = AddInTree.BuildDictionaryItems<IPartBuilder>("/Workbench/RibbonBuilders", null, false);           
        }
        /// <summary>
        /// Get Buider By buider id 
        /// </summary>
        /// <param name="buiderID">buiderid</param>
        /// <returns></returns>
        public static IPartBuilder GetBuider(string buiderID)
        {
            if (_Builders == null)
            {
                InitBuilders();
            }

            if(_Builders.ContainsKey(buiderID))
            {
                return _Builders[buiderID];           
            }
            else
            {
                throw new Exception("builder not found,please check addinTree config file");
            }
        }
    }
}
