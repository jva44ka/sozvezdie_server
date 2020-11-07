using System;

namespace Infrastructure
{
    public interface IAppSettingsManager
    {
        public string ClientUrl { get; set; }
        public string DataApiUrl { get; set; }
    }
}
