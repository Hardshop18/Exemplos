using SyncWooCommerce.Interface;
using SyncWooCommerce.Models;

namespace SyncWooCommerce.Services
{
    public class ProductServices
    {
        private IFtpServices _ftpServices;
        private IGenericEfRepository<Produto> _efProdutoRepository;
        private IWcProductRepository _wcProductRepository;
        public ProductServices(IFtpServices ftpServices, IGenericEfRepository<Produto> efProdutoRepository, IWcProductRepository wcProductRepository)
        {
            _ftpServices = ftpServices;
            _efProdutoRepository = efProdutoRepository;
            _wcProductRepository = wcProductRepository;
        }
    }
}
