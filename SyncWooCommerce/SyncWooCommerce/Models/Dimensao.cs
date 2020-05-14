namespace SyncWooCommerce.Models
{
    public class Dimensao : TabelaSincronizavel
    {
        public int cddimensao { get; set; }
        public string nmdimensao { get; set; }
        public string delinhas { get; set; }
        public string decolunas { get; set; }
        public bool flativo { get; set; }
        public int cdempresa { get; set; }
    }
}
