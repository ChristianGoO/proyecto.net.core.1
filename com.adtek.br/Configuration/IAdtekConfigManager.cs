using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.adtek.br.Configuration
{
    internal interface IAdtekConfigManager
    {
        string NorthwindConnection { get; }

        string UserName { get; }

        string Password { get; }

        string Hots { get; }

        int Port { get; }

        bool EnableSsl { get; }

        string GetConnectionString(string connectionName);

        IConfigurationSection GetConfigurationSection(string Key);
    }
}
