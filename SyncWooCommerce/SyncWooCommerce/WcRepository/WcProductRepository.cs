using SyncWooCommerce.Interface;
using System.Collections.Generic;
using WooCommerceNET.WooCommerce.v3;

namespace SyncWooCommerce.WcRepository
{
    public class WcProductRepository : IWcProductRepository
    {
        private IWcServices _wcServices;
        private readonly WCObject _wc;
        public WcProductRepository(IWcServices wcServices)
        {
            _wcServices = wcServices;
            _wc = _wcServices.GetWc();
        }

        public void Adicionar(Product entity)
        {
            _wc.Product.Add(entity);
        }

        public void Atualizar(int id, Product entity)
        {
            _wc.Product.Update(id, entity);
        }

        public async System.Threading.Tasks.Task<List<Product>> PesquisarAsync(Dictionary<string, string> parms = null)
        {
            return await _wc.Product.GetAll(parms);
        }
    }
}
