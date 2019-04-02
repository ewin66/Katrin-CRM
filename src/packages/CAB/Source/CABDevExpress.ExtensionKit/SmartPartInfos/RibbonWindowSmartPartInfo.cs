using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using DevExpress.XtraBars.Ribbon;

namespace CABDevExpress.SmartPartInfos
{
    [ToolboxBitmap(typeof(RibbonWindowSmartPartInfo), "RibbonWindowSmartPartInfo")]
    public class RibbonWindowSmartPartInfo : XtraWindowSmartPartInfo
    {
        [DefaultValue("")]
        [Browsable(false)]
        public RibbonControl Ribbon { get; set; }

        [Browsable(false)]
        [DefaultValue("")]
        public RibbonStatusBar StatusBar { get; set; }
    }
}
