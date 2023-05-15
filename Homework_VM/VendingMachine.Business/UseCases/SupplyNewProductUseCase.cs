namespace iQuest.VendingMachine.Business
{
    public class SupplyNewProductUseCase : IUseCase
    {
        IProductRepository productRepository;
        ISupplyProductView supplyProductView;

        public SupplyNewProductUseCase(IProductRepository productRepository, ISupplyProductView supplyProductView)
        {
            this.productRepository = productRepository;
            this.supplyProductView = supplyProductView;
        }

        public void Execute()
        {
            productRepository.AddOrReplace(
                supplyProductView.RequestNewProduct());
        }
    }
}
