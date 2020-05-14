using System;
using System.Collections.Generic;

namespace SyncWooCommerce.Models
{
    public class Supergrupopro : TabelaSincronizavel
    {
        public Decimal Cdsupergrupopro { get; set; }
        public string Nmsupergrupopro { get; set; }
        public bool Flativo { get; set; }
        public virtual ICollection<Grupopro> Grupopro { get; set; }
    }
}
