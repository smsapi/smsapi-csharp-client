using System.Collections.Specialized;
using System.Configuration;

namespace smsapiTests
{
    internal static class TestConfig
    {
        private static readonly NameValueCollection _settings = Load();

        public static NameValueCollection AppSettings => _settings;

        private static NameValueCollection Load()
        {
            var assemblyPath = typeof(TestConfig).Assembly.Location;
            var configMap = new ExeConfigurationFileMap { ExeConfigFilename = assemblyPath + ".config" };
            var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

            var result = new NameValueCollection();
            foreach (KeyValueConfigurationElement setting in config.AppSettings.Settings)
            {
                result[setting.Key] = setting.Value;
            }
            return result;
        }
    }
}
