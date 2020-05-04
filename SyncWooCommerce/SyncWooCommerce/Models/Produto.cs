namespace SyncWooCommerce.Models
{
    public class Produto : TabelaSincronizavel
    {
        public int cdproduto { get; set; }
        public string nmproduto { get; set; }
        public string nmreduzido { get; set; }
        public int cdaliquota { get; set; }
        public string cdunidvenda { get; set; }
        public decimal vlunitario { get; set; }
        public decimal vlunitario2 { get; set; }
        public decimal vlunitario3 { get; set; }
        public string cdbarras { get; set; }
        public bool flativo { get; set; }
        public int cdgrupopro { get; set; }
        public decimal qtestoque { get; set; }
        public int cdcalculo_Quant { get; set; }
        public int cdpai { get; set; }
        public bool flexportaecommerce { get; set; }
        public int cdprodutoant { get; set; }
        public decimal pcdescmax { get; set; }
        public string nmfoto { get; set; }
        public decimal vlpesobruto { get; set; }
        public string detamanho { get; set; }
        public int opdimensao { get; set; }
        public int cddimensao2 { get; set; }
        public int cditemdimensao2 { get; set; }
        public bool flOcultarNoEcommerce { get; set; }

        public decimal GetPrecoDoProduto(int tabelaProduto)
        {
            return tabelaProduto == 1 ? vlunitario :
                   tabelaProduto == 2 ? vlunitario2 :
                   tabelaProduto == 3 ? vlunitario3 : 0;
        }
    }
}
