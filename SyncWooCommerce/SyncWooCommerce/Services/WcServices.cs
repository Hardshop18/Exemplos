using SyncWooCommerce.Interface;
using SyncWooCommerce.Objetos;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v3;

namespace SyncWooCommerce.Services
{
    public class WcServices : IWcServices
    {
        private Configuracao _configuracaoServices;
        private readonly RestAPI _restApi;
        private readonly WCObject _wc;
        public WcServices()
        {
            _configuracaoServices = new Configuracao();
            _restApi = new RestAPI((_configuracaoServices.wooUrl + _configuracaoServices.restUrl), _configuracaoServices.wooKey, _configuracaoServices.wooSecret);
            _wc = new WCObject(_restApi);
        }

        public WCObject GetWc()
        {
            return _wc;
        }
    }
}
