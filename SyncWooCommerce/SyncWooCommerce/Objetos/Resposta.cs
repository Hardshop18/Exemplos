namespace SyncWooCommerce.Objetos
{
    public class Resposta
    {
        public bool resultado { get; set; }
        public string mensagem { get; set; }
        public string xml { get; set; }

        public static Resposta Aviso(string _msg)
        {
            return new Resposta { resultado = false, mensagem = _msg, xml = string.Empty };
        }

        public static Resposta Sucesso(string _msg = "OK", string _xml = "")
        {
            return new Resposta { resultado = true, mensagem = "OK", xml = _xml };
        }

        public static Resposta Sucesso(string _msg)
        {
            return new Resposta { resultado = true, mensagem = _msg, xml = string.Empty };
        }
    }
}
