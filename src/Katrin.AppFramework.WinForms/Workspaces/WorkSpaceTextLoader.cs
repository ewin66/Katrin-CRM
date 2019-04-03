using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Workspaces
{
    /// <summary>
    /// workspace Text Loader
    /// date:2012-11-5
    /// </summary>
   public class WorkSpaceTextLoader
    {
        //private const string FORM_CLASS = "FRM_";
        #region public methods
        /// <summary>
        /// Get list View Form Title by objectName.
        /// </summary>
        /// <param name="objectName"></param>
        /// <param name="mainText">main form Title</param>
        /// <returns></returns>
        public string GetListWorkSpaceTitle(string objectName,out string mainText)
        {
            mainText = string.Empty;
            string lstTitle = string.Empty;
            string objName = ResourceService.GetString(objectName);
            string coereryText = ResourceService.GetString("Katrin");
            string lstFormats = ResourceService.GetString("EntityListCaptionFormat");
            lstTitle = string.Format(lstFormats, objName);
            string formats = "{0}-{1}";
            mainText = string.Format(formats, lstTitle, coereryText);
            return lstTitle;
        }

        /// <summary>
        /// get detailwork space title by objectname
        /// </summary>
        /// <param name="objectName"></param>
        /// <returns></returns>
        public string GetDetailWorkSpaceTitle(string objectName)
        {
            string detailText = string.Empty;
            string title = ResourceService.GetString(objectName);
            string coereryText = ResourceService.GetString("Katrin");
            string formats = ResourceService.GetString("EntityDetailsCaptionFormat") + "-{1}";
            detailText = string.Format(formats, title, coereryText);
            return detailText;
        }
        #endregion
    }
}
