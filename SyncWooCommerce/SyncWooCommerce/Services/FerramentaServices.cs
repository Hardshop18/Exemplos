using SyncWooCommerce.Interface;
using SyncWooCommerce.Utilitarios;
using System;

namespace SyncWooCommerce.Services
{
    public class FerramentaServices : IFerramentaServices
    {
        private string _assuntoEmail = "Sincronização com Erro";
        private string _site = string.Empty;
        private IEmailServices _emailServices;
        public FerramentaServices(IEmailServices emailServices)
        {
            _emailServices = emailServices;
        }

        public void SetSite(string site)
        {
            _site = site;
        }

        public void TrataErro(Exception exception, string codigo, bool sincFinalizada = false)
        {
            string msg = exception.Message;
            TrataErro(msg, codigo, sincFinalizada);
        }

        public void TrataErro(string msg, string codigo, bool sincFinalizada = false)
        {
            Log.GravarLog(sincFinalizada ? "Sincronização finalizada" : $"Erro: {msg} no produto {codigo}");
            _emailServices.Enviar(_assuntoEmail, $"O WooSync da {_site} está apresentando o seguinte erro: " +
                                $"{msg} no produto {codigo}");
        }

        public void TrataAviso(Exception exception, string codigo)
        {
            string msg = exception.Message;
            TrataAviso(msg, codigo);
        }

        public void TrataAviso(string msg, string codigo)
        {
            Log.GravarLog($"Id sinca: {codigo} Aviso: {msg}");
            _emailServices.Enviar(_assuntoEmail, $"O WooSync da {_site} está apresentando o seguinte aviso: " +
                                $"{msg} no produto {codigo}");
        }
    }
}
