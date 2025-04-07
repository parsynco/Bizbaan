using BlazorDB;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Parysn.Apps.Admin.UIServices
{
    public class InMemeoryStorage(IBlazorDbFactory dbFactory)
    {
        private readonly IBlazorDbFactory _dbFactory = dbFactory;
        private readonly ICollection<StoreDataStructure> _store = [];
        private readonly string _dbName = "BizbaanDB";
        private readonly string _tableName = "Bizbaan";

        private IndexedDbManager _dbManager { get; set; }
        public async Task InitManager()
        {
            _dbManager = await _dbFactory.GetDbManager(_dbName);
            await _dbManager.OpenDb();
        }
        public async void Store<T>(string key, T data)
        {
            await InitManager();
            await _dbManager.AddRecord(new StoreRecord<T>()
            {
                StoreName = _tableName,
                Record = data,
                DbName = _dbName
            });
        }
        public async void Remove<T>()
        {
            await _dbManager.ClearTableAsync(_tableName);
        }
        public async Task<T> Read<T>(string key)
        {
            try
            {
                await InitManager();
            }
            catch { }
            var records = await _dbManager.ToArray<T>(_tableName);
            if (records.Count > 0)
                return records[0];
            return default;
        }
    }
    internal class StoreDataStructure
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
