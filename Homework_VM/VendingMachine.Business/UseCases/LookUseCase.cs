

namespace iQuest.VendingMachine.Business
{
    public class LookUseCase : IUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly IShelfView view;

        public string Name => "See products";

        public string Description => "This is our stock.";

        public bool CanExecute => productRepository.GetProducts().Any();

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
