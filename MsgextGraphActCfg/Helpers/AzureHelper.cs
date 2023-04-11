using Azure.Data.AppConfiguration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MsgextGraphSrchCfg.Models;

namespace MsgextGraphSrchCfg.Helpers
{
    public class AzureHelper
    {
        private readonly ConfigurationClient _client;
        public AzureHelper(IConfiguration config) 
        {
            string _connectionString = config["AZURE_CONFIG_CONNECTION_STRING"];
            _client = new ConfigurationClient(_connectionString);
        }

        public void storeConfigValue(string key, string value)
        {
            _client.SetConfigurationSetting(key, value);
        }
        public string GetConfigurationValue(string key)
        {
            var configValue = _client.GetConfigurationSetting(key);
            if (configValue != null)
            {
                return configValue.Value.Value;
            }
            else { return ""; }
        }
    }
}
