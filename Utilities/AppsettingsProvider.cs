using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Utilities
{
    public static class AppsettingsProvider
    {
        private static readonly IConfigurationRoot configuration;
        static AppsettingsProvider()
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();
        }

        public static string GetAzureStorageConstring()
        {
            return configuration["appSettings:azureStorageConstring"];
        }
        public static string GetAzureStorageContainer()
        {
            return configuration["appSettings:azureStorageContainer"];
        }


    }
}
