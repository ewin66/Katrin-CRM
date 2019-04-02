using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.Security
{
    public interface IUserData
    {
        string Name { get; set; }
        string Password { get; set; }
        string[] Roles { get; set; }
    }
}
