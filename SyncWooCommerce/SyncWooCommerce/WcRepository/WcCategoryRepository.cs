using SyncWooCommerce.Interface;
using WooCommerceNET.WooCommerce.v3;

namespace SyncWooCommerce.WcRepository
{
    public class WcCategoryRepository : IWcCategoryRepository
    {
        private IWcServices _wcServices;
        private readonly WCObject _wc;
        public WcCategoryRepository(IWcServices wcServices)
        {
            _wcServices = wcServices;
            _wc = _wcServices.GetWc();
        }

        public void Adicionar(ProductCategory entity)
        {
            _wc.Category.Add(entity);
        }

        public void Atualizar(int id, ProductCategory entity)
        {
            _wc.Category.Update(id, entity);
        }
    }
}
