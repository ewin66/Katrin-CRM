using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Katrin.AppFramework
{
    public class DisposeAction : IDisposable
    {
        Action callback;

        public DisposeAction(Action callback)
		{
			if (callback == null)
				throw new ArgumentNullException("callback");
			this.callback = callback;
		}

        public void Dispose()
        {
            Action action = Interlocked.Exchange(ref callback, null);
            if (action != null)
            {
                action();
#if DEBUG
                ////GC.SuppressFinalize(this);
#endif
            }
        }

        #if DEBUG
        ~DisposeAction()
		{
			Debug.Fail("CallbackOnDispose was finalized without being disposed.");
		}
		#endif
    }
}
