using WooCommerceNET.WooCommerce.v3;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SyncWooCommerce.Interface
{
    public interface IWcOrdersRepository
    {
        Task<List<Order>> GetPedidoWc(int cdproduto);
        int GetCalculaQuantidadeProdutoNoPedido(List<Order> orders, int cdproduto, int cdprodutoFilho = 0);
    }
}
