using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Katrin.AppFramework
{
    public interface ISelectionContext
    {
        object CurrentObject { get; }
        IList SelectedObjects { get; }
        SelectionType SelectionType { get; }
        string Name { get; }
        bool IsRoot { get; }
        event EventHandler CurrentObjectChanged;
        event EventHandler SelectionChanged;
        event EventHandler SelectionTypeChanged;
    }
}
