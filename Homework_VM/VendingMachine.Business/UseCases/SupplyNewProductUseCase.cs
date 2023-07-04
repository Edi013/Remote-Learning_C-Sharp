namespace iQuest.VendingMachine.Business
{
    public class SupplyNewProductUseCase : IUseCase
    {
        IProductAndSalesUnitOfWork _productAndSalesUnitOfWork;
        ISupplyProductView supplyProductView;

        public SupplyNewProductUseCase(IProductAndSalesUnitOfWork productAndSalesUnitOfWork, ISupplyProductView supplyProductView)
        {
            _productAndSalesUnitOfWork = productAndSalesUnitOfWork;
            this.supplyProductView = supplyProductView;
        }

        public void Execute()
        {
            _productAndSalesUnitOfWork.ProductRepository.AddOrReplace(
                supplyProductView.RequestNewProduct());
            _productAndSalesUnitOfWork.SaveChanges();
        }
    }
}
