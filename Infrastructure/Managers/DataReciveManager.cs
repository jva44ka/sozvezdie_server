using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Newtonsoft.Json;

namespace Infrastructure.Managers
{
    public class DataReciveManager : IDataReciveManager
    {
        private readonly IAppSettingsManager _configuration;

        public DataReciveManager(IAppSettingsManager configuration)
        {
            _configuration = configuration;
        }

        public T GetData<T>()
        {
            var json = new WebClient().DownloadString(_configuration.DataApiUrl);
            var result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }

        public async Task<T> GetDataAsync<T>()
        {
            var json = await new HttpClient().GetStringAsync(_configuration.DataApiUrl);
            var result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }
    }
}
