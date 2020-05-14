using System.Configuration;

namespace WooCommerc
{
    public class Configuracao
    {
        private string wooUrl { get; set; }
        private string restUrl { get; set; }
        public string url { get; private set; }
        public string wooKey { get; private set; }
        public string wooSecret { get; private set; }

        public Configuracao()
        {
            wooUrl    = GetConfiguracao("wooUrl");
            restUrl   = GetConfiguracao("restUrl");
            url       = wooUrl + restUrl;
            wooKey    = GetConfiguracao("wooKey");
            wooSecret = GetConfiguracao("wooSecret");
        }

        private static string GetConfiguracao(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }
    }
}
