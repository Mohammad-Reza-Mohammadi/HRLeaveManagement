using Hanssens.Net;
using HRLeaveManagement.MVC.Contracts;
using System.Runtime.CompilerServices;

namespace HRLeaveManagement.MVC.Services
{
    public class LocalStorageService : ILocalStorgeService
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


        public void ClearStorge(List<string> keys)
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

        public T GetStorgeValue<T>(string key)
        {
            return _storage.Get<T>(key);
        }

        public void SetStorageValue<T>(string key, T Value)
        {
            _storage.Store(key, Value);
            _storage.Persist();
        }
    }
}
