using SyncWooCommerce.Utilitarios;

namespace SyncWooCommerce.Objetos
{
    public class Configuracao
    {
        public string wooUrl { get; }
        public string wooKey { get; }
        public string wooSecret { get; }
        public string restUrl { get; }

        public string ftpUrl { get; }
        public string ftpUsuario { get; }
        public string ftpSenha { get; }

        public string pathSinca { get; }

        public int idvendedor { get; }

        public int tabelaPrecoParaPrice { get; }
        public int tabelaPrecoParaSalePrice { get; }

        public bool sincronizarSuperGrupoPro { get; }
        public int tipoSincronizacaoEstoque { get; }

        public Configuracao()
        {
            wooUrl = ArquivoDeConfiguracao.GetConfiguracao("wooUrl");//"http://hardshop.com.br/testesite/lv-skyboard/";
            restUrl = ArquivoDeConfiguracao.GetConfiguracao("restUrl");//"wp-json/wc/v3/";
            wooKey = ArquivoDeConfiguracao.GetConfiguracao("wooKey");//"ck_55522de6de861eb8c7ce31f6f944342261a53003";
            wooSecret = ArquivoDeConfiguracao.GetConfiguracao("wooSecret");//"cs_c5e256c8f0b30b6b3177c2fed0e2c9a52d1c39ed";

            ftpUrl = ArquivoDeConfiguracao.GetConfiguracao("ftpUrl");//"ftp://hardshop.com.br/public_html/testesite/lv-skyboard/wp-content/uploads/";
            ftpUsuario = ArquivoDeConfiguracao.GetConfiguracao("ftpUsuario");//"hardshop1";
            ftpSenha = ArquivoDeConfiguracao.GetConfiguracao("ftpSenha");//"a0ntsctvef";

            pathSinca = ArquivoDeConfiguracao.GetConfiguracao("pathSinca");//@"C:\Sinca skyboard\";

            try
            {
                int id = 0;
                int.TryParse(ArquivoDeConfiguracao.GetConfiguracao("idvendedor"), out id);
                idvendedor = id;
            }
            catch { }

            try
            {
                int id = 1;
                int.TryParse(ArquivoDeConfiguracao.GetConfiguracao("TabelaPrecoParaPrice"), out id);
                tabelaPrecoParaPrice = id == 0 ? 1 : id;
            }
            catch { }

            try
            {
                int id = 0;
                int.TryParse(ArquivoDeConfiguracao.GetConfiguracao("TabelaPrecoParaSalePrice"), out id);
                tabelaPrecoParaSalePrice = id;
            }
            catch { }

            try
            {
                bool logical = false;
                bool.TryParse(ArquivoDeConfiguracao.GetConfiguracao("SincronizarSuperGrupoPro"), out logical);
                sincronizarSuperGrupoPro = logical;
            }
            catch { }

            try
            {
                int id = 1;
                int.TryParse(ArquivoDeConfiguracao.GetConfiguracao("TipoSincronizacaoEstoque"), out id);
                tipoSincronizacaoEstoque = id == 0 ? 1 : id; // 1 - Estoque do Sinca / 2 - Não atualiza estoque / 3 - Estoque do sinca - as vendas do WC
            }
            catch { }
        }

        public string PathFtpParaPathHtml()
        {
            string rep = wooUrl.ToUpper();
            return ftpUrl.ToLower().Replace("ftp", rep.Contains("HTTPS") ? "HTTPS" : "HTTP").Replace("public_html/", "");
        }
    }
}
