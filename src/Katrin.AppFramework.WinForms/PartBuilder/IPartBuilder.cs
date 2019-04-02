using ICSharpCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms
{
    public interface IPartBuilder
    {
        object Build(Codon codon, object caller, IEnumerable<ICondition> conditions);
        void Init(object part, object item);
    }

    public abstract class AbstractPartBuilder : IPartBuilder
    {
        public abstract object Build(Codon codon, object caller, IEnumerable<ICondition> conditions);

        public virtual void Init(object part, object item)
        {
        }
    }
}
