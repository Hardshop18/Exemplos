using System;

namespace SyncWooCommerce.Models
{
    public class Grupopro : TabelaSincronizavel
    {
        public int cdgrupopro { get; set; }
        public string nmgrupopro { get; set; }
        public bool flservico { get; set; }
        public bool flativo { get; set; }
        public Decimal cdsupergrupopro { get; set; }
    }
}
