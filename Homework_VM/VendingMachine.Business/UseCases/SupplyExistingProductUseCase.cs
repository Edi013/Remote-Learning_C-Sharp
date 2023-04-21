using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Business
{
    public class SupplyExistingProductUseCase : IUseCase
    {
        IProductRepository productRepository;
        ISupplyProductView supplyProductView;

        public SupplyExistingProductUseCase(IProductRepository productRepository, ISupplyProductView supplyProductView)
        {
            this.productRepository = productRepository;
            this.supplyProductView = supplyProductView;
        }

        public void Execute()
        {
            productRepository.IncreaseQuantity(
                supplyProductView.RequestProductQuantity());
        }
    }
}
