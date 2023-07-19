using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.adtek.br.Configuration
{
    public class AdtekConfigManager : IAdtekConfigManager
    {
        private readonly IConfiguration _configuration;

        public AdtekConfigManager(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string NorthwindConnection
        {
            get
            {
                return this.GetConfiguration("ConnectionStrings:NorthwindDatabase", string.Empty);
            }
        }

        public string UserName
        {
            get
            {
                return this.GetConfiguration("AppSeettings:userName", string.Empty);
            }
        }

        public string Password
        {
            get
            {
                return this.GetConfiguration("AppSeettings:password", string.Empty);
            }
        }

        public string Hots
        {
            get
            {
                return this.GetConfiguration("AppSeettings:hots", string.Empty);
            }
        }

        public int Port
        {
            get
            {
                return this.GetConfiguration("AppSeettings:port", 0);
            }
        }

        public bool EnableSsl
        {
            get
            {
                return this.GetConfiguration("AppSeettings:hots", false);
            }
        }

        public IConfigurationSection GetConfigurationSection(string Key)
        {
            return this._configuration.GetSection(Key);
        }

        public string GetConnectionString(string connectionName)
        {
            var valconfig = this._configuration.GetConnectionString(connectionName);
            return string.IsNullOrEmpty(valconfig) ? String.Empty : valconfig;
        }

        public string GetConfiguration(string key, string defaultValue) 
        {
            var valconfig = this._configuration[key];
            return string.IsNullOrEmpty(valconfig) ? defaultValue : valconfig;
        }

        public int GetConfiguration(string key, int defaultValue)
        {
            var valconfig = this._configuration[key];
            return string.IsNullOrEmpty(valconfig) ? defaultValue : int.Parse( valconfig);
        }

        public bool GetConfiguration(string key, bool defaultValue)
        {
            var valconfig = this._configuration[key];
            return string.IsNullOrEmpty(valconfig) ? defaultValue : bool.Parse(valconfig);
        }

    }
}
