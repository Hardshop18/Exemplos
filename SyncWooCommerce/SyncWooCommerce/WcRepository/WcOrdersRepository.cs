using SyncWooCommerce.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WooCommerceNET.WooCommerce.v3;

namespace SyncWooCommerce.WcRepository
{
    public class WcOrdersRepository : IWcOrdersRepository
    {
        private IWcServices _wcServices;
        private readonly WCObject _wc;
        public WcOrdersRepository(IWcServices wcServices)
        {
            _wcServices = wcServices;
            _wc = _wcServices.GetWc();
        }

        public async Task<List<Order>> GetPedidoWc(int cdproduto)
        {
            var consulta = new Dictionary<string, string>();
            consulta.Add("per_page", "100");
            consulta.Add("status", "on-hold, processing, pending");
            consulta.Add("product", cdproduto.ToString());
            return await _wc.Order.GetAll(consulta);
        }

        public int GetCalculaQuantidadeProdutoNoPedido(List<Order> orders, int cdproduto, int cdprodutoFilho = 0)
        {
            int qtde = 0;
            IEnumerable<decimal?> itens;
            try
            {
                if (cdprodutoFilho > 0)
                    itens = orders.Select(c => c.line_items.Where(w => w.variation_id == cdproduto).Sum(s => s.quantity));
                else
                    itens = orders.Select(c => c.line_items.Where(w => w.product_id == cdproduto).Sum(s => s.quantity));
                qtde = Convert.ToInt32(itens.Sum(w => w.Value));
            }
            catch { }
            return qtde;
        }
    }
}
