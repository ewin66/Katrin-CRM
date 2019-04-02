using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.CompositeUI;

namespace Katrin.Win.Infrastructure.Services
{
    public interface IUserDataPersister
    {
        void SaveUserData(State state);
        void LoadUserData(State state);
    }
}
