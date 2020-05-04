using WooCommerceNET.WooCommerce.v3;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SyncWooCommerce.Interface
{
    public interface IWcVariantRepository
    {
        void Adicionar(Variation entity, int parentId);

        void Atualizar(int id, Variation entity, int parentId);

        Task<List<Variation>> PesquisarAsync(Dictionary<string, string> parms = null);
    }
}
