namespace SyncWooCommerce.Models
{
    public class Sincronizacao
    {
        public int cdsincronizacao { get; set; }
        public int cdintegracao { get; set; }
        public string cdtabela { get; set; }
        public decimal tsultimasincronizacao { get; set; }

        public string GetTsultimasincronizacaoToString()
        {
            return ((int)tsultimasincronizacao).ToString();
        }
    }
}
