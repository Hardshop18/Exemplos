using WooCommerceNET.WooCommerce.v3;

namespace SyncWooCommerce.Interface
{
    public interface IWcCategoryRepository
    {
        void Adicionar(ProductCategory entity);
        void Atualizar(int id, ProductCategory entity);
    }
}
