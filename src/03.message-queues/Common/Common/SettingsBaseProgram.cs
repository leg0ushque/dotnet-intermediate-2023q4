using Microsoft.Extensions.Configuration;
using System.IO;

namespace Common
{
    public abstract class SettingsBaseProgram
    {
        protected static IConfiguration _configuration;

        protected static void SetupSettingsJson()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("settings.json", false)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
