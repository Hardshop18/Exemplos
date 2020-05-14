using SyncWooCommerce.Interface;
using SyncWooCommerce.Objetos;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace SyncWooCommerce.Services
{
    public class FtpServices : IFtpServices
    {
        private FileInfo arquivoInfo;
        public FtpServices()
        {
        }

        public string RetirarCaracteresDoNomeDoArquivo(string fileName)
        {
            Regex r = new Regex("(?:[^a-z0-9. ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            string fileRename = r.Replace(fileName, String.Empty);

            if (fileRename.IndexOf(".") != fileRename.LastIndexOf("."))
                fileRename = fileRename.Remove(fileRename.IndexOf("."), 1);
            if (fileRename.IndexOf(".") != fileRename.LastIndexOf("."))
                fileRename = RetirarCaracteresDoNomeDoArquivo(fileRename);
            return fileRename;
        }

        private string Tratar(string arquivo)
        {
            arquivoInfo = new FileInfo(arquivo);
            return "fotos/" + RetirarCaracteresDoNomeDoArquivo(arquivoInfo.Name);
        }

        public Resposta EnviarArquivoFtp(string arquivo, string url, string usuario, string senha)
        {
            try
            {
                DeletarArquivoFtp(arquivo, url, usuario, senha);
                string nomeArquivo = Tratar(arquivo);
                var request = (System.Net.FtpWebRequest)System.Net.WebRequest.Create(url + nomeArquivo);

                request.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new System.Net.NetworkCredential(usuario, senha);
                request.UseBinary = true;
                request.ContentLength = arquivoInfo.Length;
                using (FileStream fs = arquivoInfo.OpenRead())
                {
                    byte[] buffer = new byte[2048];
                    int bytesSent = 0;
                    int bytes = 0;
                    using (Stream stream = request.GetRequestStream())
                    {
                        while (bytesSent < arquivoInfo.Length)
                        {
                            bytes = fs.Read(buffer, 0, buffer.Length);
                            stream.Write(buffer, 0, bytes);
                            bytesSent += bytes;
                        }
                    }
                }
                return Resposta.Sucesso(nomeArquivo);
            }
            catch (Exception e)
            {
                return Resposta.Aviso(e.Message);
            }
        }

        private void DeletarArquivoFtp(string arquivo, string url, string usuario, string senha)
        {
            try
            {
                FileInfo arquivoInfo = new FileInfo(arquivo);
                string nomeArquivo = RetirarCaracteresDoNomeDoArquivo(arquivoInfo.Name);
                var request = (System.Net.FtpWebRequest)System.Net.WebRequest.Create(url + nomeArquivo);
                request.Method = System.Net.WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = new System.Net.NetworkCredential(usuario, senha);
                var response = request.GetResponse();
            }
            catch { }
        }
    }
}
