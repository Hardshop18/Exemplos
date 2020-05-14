using SyncWooCommerce.Interface;
using System;

namespace SyncWooCommerce.Models
{
    public abstract class TabelaSincronizavel
    {
        public Decimal timestamp;
        public string guid;
        public bool flexcluido;
    }
}
