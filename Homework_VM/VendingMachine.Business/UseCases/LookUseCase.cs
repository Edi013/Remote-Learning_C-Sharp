

namespace iQuest.VendingMachine.Business
{
    public class LookUseCase : IUseCase
    {
        private readonly IShelfView view;
        private readonly IProductRepository productRepository;

        public LookUseCase(IProductRepository products, IShelfView view)
        {
            this.productRepository = products ?? throw new ArgumentNullException(nameof(products));
            this.view = view ?? throw new ArgumentNullException(nameof(view));
        }            

        public void Execute()
        {
            view.DisplayProducts(productRepository.GetProducts());
        }
    }
}
