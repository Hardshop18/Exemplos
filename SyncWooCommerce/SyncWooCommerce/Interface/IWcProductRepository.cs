using WooCommerceNET.WooCommerce.v3;
using System.Collections.Generic;

namespace SyncWooCommerce.Interface
{
    public interface IWcProductRepository
    {
        void Adicionar(Product entity);
        void Atualizar(int id, Product entity);
        System.Threading.Tasks.Task<List<Product>> PesquisarAsync(Dictionary<string, string> parms = null);
    }
}
