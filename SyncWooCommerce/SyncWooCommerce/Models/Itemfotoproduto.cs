namespace SyncWooCommerce.Models
{
    public class ItemFotoProduto : TabelaSincronizavel
    {
        public int cditemfotoproduto { get; set; }
        public int cdproduto { get; set; }
        public int nritem { get; set; }
        public int cdfoto { get; set; }
        public int cdempresa { get; set; }
    }
}
