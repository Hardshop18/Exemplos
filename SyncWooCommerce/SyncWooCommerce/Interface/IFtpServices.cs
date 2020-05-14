using SyncWooCommerce.Objetos;

namespace SyncWooCommerce.Interface
{
    public interface IFtpServices
    {
        string RetirarCaracteresDoNomeDoArquivo(string fileName);
        Resposta EnviarArquivoFtp(string arquivo, string url, string usuario, string senha);
    }
}
