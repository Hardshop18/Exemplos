using System;
using System.IO;
using System.Text;

namespace SyncWooCommerce.Utilitarios
{
    public class Log
    {
        private static string _pastaDoLog = "Logs";
        private static void CriaDiretorioLog()
        {
            if (!Directory.Exists(_pastaDoLog))
                Directory.CreateDirectory(_pastaDoLog);
        }

        private static void Gravar(string texto)
        {
            using (StreamWriter writer = new StreamWriter(string.Format("{0}/{1}log.txt", _pastaDoLog, DateTime.Now.ToString("yyyy-MM-dd")), true, Encoding.UTF8))
            {
                writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + " - " + texto);
            }
        }

        public static void GravarLog(string texto)
        {
            CriaDiretorioLog();
            Gravar(texto);
        }
    }
}
