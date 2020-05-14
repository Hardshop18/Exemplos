namespace SyncWooCommerce.Interface
{
    public interface IEmailServices
    {
        bool IsValid(string enderecoEmail);
        string Enviar(string assunto, string mensagem);
    }
}
