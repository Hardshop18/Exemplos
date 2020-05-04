using System;

namespace SyncWooCommerce.Models
{
    public class Estoque : TabelaSincronizavel
    {
        public int cdestoque { get; set; }
        public int cdproduto { get; set; }
        public decimal qtestoque { get; set; }
        public decimal vlcustomedio { get; set; }
        public decimal vlultcompra { get; set; }
        public DateTime dtultcompra { get; set; }
        public decimal qtestoquediaant { get; set; }
        public DateTime dtestoquediaant { get; set; }
        public string md5_e2 { get; set; }
        public decimal cdultimacompra { get; set; }
        public decimal qtreservado { get; set; }
        public decimal qtcondicional { get; set; }
    }
}
