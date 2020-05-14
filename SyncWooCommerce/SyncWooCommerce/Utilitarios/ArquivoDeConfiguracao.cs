using System.Configuration;

namespace SyncWooCommerce.Utilitarios
{
    public class ArquivoDeConfiguracao
    {
        public static void SetConfiguracao(string name, string value)
        {
            ConfigurationManager.AppSettings.Set(name, value);
        }
        public static string GetConfiguracao(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }
    }
}
