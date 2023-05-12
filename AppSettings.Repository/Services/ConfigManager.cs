using AppSettings.Models;
using AppSettings.Repository.Interface;
using Microsoft.Extensions.Options;

namespace AppSettings.Repository.Services
{
    public class ConfigManager : IConfigManager
    {
        private readonly IOptions<Config> _configuration;

        public ConfigManager(IOptions<Config> configuration)
        {
            this._configuration = configuration;
        }

        public string NorthwindConnection
        {
            get
            {
                return this._configuration.Value.WindConnection;
            }
        }

        public string GetConnectionString(string connectionName)
        {
            return "";// this._configuration.GetConnectionString(connectionName);
        }

        public string EmailID
        {
            get
            {
                return this._configuration.Value.EmailID;
            }
        }

        public string AccountKey
        {
            get
            {
                return this._configuration.Value.AccountKey;
            }
        }

        //public IConfigurationSection GetConfigurationSection(string key)
        //{
        //    return this._configuration.GetSection(key);
        //}


        public string Test()
        {
            return this._configuration.Value.ConnectionString;
        }

        public async Task<string> TestDBConnector()
        {
            string result = string.Empty;

            result = $"MyAccount:{_configuration?.Value?.AccountKey}, DBConnection:{_configuration?.Value?.ConnectionString}, Email:{_configuration?.Value?.EmailID}";

            return await Task.Run(() => result);
        }
    }
}
