using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.Data
{
    public interface IFieldProjectStrategy
    {
        string Project(string fieldName);
        string UnProject(string projectedName);
    }
}
