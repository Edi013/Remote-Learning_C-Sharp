using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Business
{
    public class SupplyExistingProductUseCase : IUseCase
    {
        private ISupplyProductView _supplyProductView;
        private IProductAndSalesUnitOfWork _productAndSalesUnitOfWork;

        public SupplyExistingProductUseCase(IProductAndSalesUnitOfWork productAndSalesUnitOfWork, ISupplyProductView supplyProductView)
        {
            _productAndSalesUnitOfWork = productAndSalesUnitOfWork;
            this._supplyProductView = supplyProductView;
        }

        public void Execute()
        {
            QuantitySupply quantitySupply = _supplyProductView.RequestProductQuantity();
            Product product = _productAndSalesUnitOfWork.ProductRepository.GetProductByColumnId(quantitySupply.ColumnId);

            if (product == null)
                throw new Exception("Accessed product does not exists !");

            product.Quantity += quantitySupply.Quantity;
            _productAndSalesUnitOfWork.ProductRepository.Update(product);

            _productAndSalesUnitOfWork.SaveChanges();
        }
    }
}
