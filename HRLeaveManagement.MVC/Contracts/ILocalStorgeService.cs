namespace HRLeaveManagement.MVC.Contracts
{
    public interface ILocalStorgeService
    {
        void ClearStorge(List<string> keys);
        bool Exists(string key);
        T GetStorgeValue<T>(string key);
        void SetStorageValue<T>(string key, T Value);
    }
}
