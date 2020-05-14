using System;

namespace SyncWooCommerce.Interface
{
    public interface IFerramentaServices
    {
        void SetSite(string site);
        void TrataErro(Exception exception, string codigo, bool sincFinalizada = false);
        void TrataErro(string msg, string codigo, bool sincFinalizada = false);
        void TrataAviso(Exception exception, string codigo);
        void TrataAviso(string msg, string codigo);
    }
}
