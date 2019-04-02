using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.Test
{
    [Export(typeof(IPartManager<IMenuPart>))]
    public class MenuManager : PartManager<IMenuPart, IMenuPartMetaData>
    {
    }
}
