using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.Security
{
    public class UserData : IUserData
    {
        private string _name;
        private string _password;
        private string[] _roles;

        public string[] Roles
        {
            get { return _roles; }
            set { _roles = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}
