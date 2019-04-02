using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

using Illusion;

namespace Illusion.Demo.ViewModels
{
    [DockScreen(Type = DockType.Document)]
    public class DesignerViewModel : AvalonDockScreen, IDockDocumentScreen
	{
		public DesignerViewModel()
			: base(WorkbenchName.DesignerScreen)
		{
		}
	}
}
