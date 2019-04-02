using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.Messages.MessageDefine
{
    /// <summary>
    /// Message AppType.
    /// author:hecq
    /// date:2012-11-15
    /// </summary>
    public enum MsgAppTypes
    {
        /// <summary>
        /// Message will be sended to All objected in App if which need
        /// </summary>
        App =0,
        /// <summary>
        /// Message only be sended to object in specifed workspace.
        /// </summary>
        WorkSpace
    }
}
