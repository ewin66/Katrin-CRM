using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.WinForms.MVC
{
    /// <author>Mohamadou Yacoubou</author>
    /// <summary>
    /// Asynchronous attribute marks an action as an asynchronous action
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class AsynchronousAttribute : Attribute
    {
    }
}
