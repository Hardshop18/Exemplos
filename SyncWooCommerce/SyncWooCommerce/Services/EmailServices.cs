using SyncWooCommerce.Interface;
using System;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace SyncWooCommerce.Services
{
    public class EmailServices : IEmailServices
    {
        private SmtpClient _smtpClient;
        private MailMessage _mensagemEmail;

        private string _remetente = "sincanfe@gmail.com";
        private string _destinatario = "marketing@hardshop.com.br";

        public EmailServices()
        {
            PrepararConfiguracaoEmail();
        }

        private void PrepararConfiguracaoEmail()
        {
            _smtpClient = new SmtpClient("smtp.gmail.com", 587);
            _smtpClient.EnableSsl = true;
            // inclui as credenciais
            _smtpClient.UseDefaultCredentials = false;
            _smtpClient.Credentials = new NetworkCredential("sincanfe@gmail.com", "hardsincanfe");
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        }

        private void CriaEmail(string assunto, string enviaMensagem)
        {
            _mensagemEmail = new MailMessage(_remetente, _destinatario, assunto, enviaMensagem);
            _mensagemEmail.CC.Add(new System.Net.Mail.MailAddress("hardshopmobile@gmail.com"));
        }

        private void EnviaEmail()
        {
            _smtpClient.Send(_mensagemEmail);
        }

        public bool IsValid(string enderecoEmail)
        {
            try
            {
                Regex expressaoRegex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");
                return expressaoRegex.IsMatch(enderecoEmail);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string Enviar(string assunto, string mensagem)
        {
            try
            {
                // Se o email não é validao retorna uma mensagem
                if (IsValid(_destinatario) == false)
                    return "Email do destinatário inválido: " + _destinatario;

                CriaEmail(assunto, mensagem);

                // envia a mensagem
                EnviaEmail();

                return "Mensagem enviada para  " + _destinatario + " às " + DateTime.Now.ToString() + ".";
            }
            catch (Exception ex)
            {
                string erro = ex.InnerException.ToString();
                return ex.Message.ToString() + erro;
            }
        }

        /*public async Task<Resposta> EnviarEmailInicial()
        {
            string dataInicializacao = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            EnviarMensagemEmail("Iniciando Sincronizador", $"{_siteEmpresa} iniciou o WooSync às {dataInicializacao}");
            return Resposta.Sucesso();
        }

        public void EnviarEmailDeErro(string enviaMensagem)
        {
            EnviarMensagemEmail("Sincronizador com Erro", String.Format(enviaMensagem, _siteEmpresa));
        }*/
    }
}
