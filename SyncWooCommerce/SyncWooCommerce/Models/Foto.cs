namespace SyncWooCommerce.Models
{
    public class Foto : TabelaSincronizavel
    {
        public int cdfoto { get; set; }
        public string nmfoto { get; set; }
        public string nmarquivofoto { get; set; }
        public string md5 { get; set; }
        public bool flativo { get; set; }
        public int cdempresa { get; set; }
    }
}
