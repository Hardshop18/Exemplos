using SyncWooCommerce.Interface;
using System.Collections.Generic;
using WooCommerceNET.WooCommerce.v3;

namespace SyncWooCommerce.WcRepository
{
    public class WcVariantRepository : IWcVariantRepository
    {
        private IWcServices _wcServices;
        private readonly WCObject _wc;
        public WcVariantRepository(IWcServices wcServices)
        {
            _wcServices = wcServices;
            _wc = _wcServices.GetWc();
        }

        public void Adicionar(Variation entity, int parentId)
        {
            _wc.Product.Variations.Add(entity, parentId);
        }

        public void Atualizar(int id, Variation entity, int parentId)
        {
            _wc.Product.Variations.Update(id, entity, parentId);
        }

        public async System.Threading.Tasks.Task<List<Variation>> PesquisarAsync(Dictionary<string, string> parms = null)
        {
            return await _wc.Product.Variations.GetAll(parms);
        }
    }
}
