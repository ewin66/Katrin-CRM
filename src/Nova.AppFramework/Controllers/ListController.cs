using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.Controllers
{
    [Export(typeof(IPartManager<IMenuPart>))]
    public class ListController : PartManager<IMenuPart, IMenuPartMetaData>
    {

    }
}
