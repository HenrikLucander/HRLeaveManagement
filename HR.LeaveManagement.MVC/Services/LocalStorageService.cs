using Hanssens.Net;
using HR.LeaveManagement.MVC.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.MVC.Services
{
    // client needs a way to store jwt tokens, thus we implement localStorageService
    public class LocalStorageService : ILocalStorageService
    {
        private LocalStorage _storage;

        public LocalStorageService()
        {
            var config = new LocalStorageConfiguration()
            {
                AutoLoad = true,
                AutoSave = true,
                Filename = "HR.LEAVEMGMT"
            };
            _storage = new LocalStorage(config);
        }

        public void ClearStorage(List<string> keys)
        {
            foreach(var key in keys)
            {
                _storage.Remove(key);
            }
        }

        public bool Exists(string key)
        {
            return _storage.Exists(key);
        }

        public T GetStorageValue<T>(string key)
        {
            return _storage.Get<T>(key);
        }

        public void SetStorageValue<T>(string key, T value)
        {
            _storage.Store(key, value);
            _storage.Persist();
        }
    }
}
