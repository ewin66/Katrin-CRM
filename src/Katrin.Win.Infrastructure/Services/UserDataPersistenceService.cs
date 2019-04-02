using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Services;

namespace Katrin.Win.Infrastructure.Services
{
    public class UserDataPersistenceService
    {
        private readonly IStatePersistenceService _persistenceService = new FileStatePersistenceService();
        private readonly State _state;

        public UserDataPersistenceService(string id)
        {
            _state = _persistenceService.Contains(id) ? _persistenceService.Load(id) : new State(id);
        }

        public void LoadUserData(IUserDataPersister persister)
        {
            persister.LoadUserData(_state);
        }

        public void SaveUserData(IUserDataPersister persister)
        {
            persister.SaveUserData(_state);
            Save();
        }

        public object this[string key]
        {
            get { return _state[key]; }
            set { _state[key] = value; }
        }

        public void Save()
        {
            _persistenceService.Save(_state);
        }
    }
}
