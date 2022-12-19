using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.PresentationLayer;

namespace iQuest.VendingMachine.UseCases
{
    internal class LookUseCase : IUseCase
    {
        private readonly ProductRepository productRepository;
        private readonly ShelfView view;

        public string Name => "See products";

        public string Description => "This is our stock.";

        public bool CanExecute => productRepository.GetAll().Any();

        public LookUseCase(ProductRepository products, ShelfView view)
        {
            this.productRepository = products ?? throw new ArgumentNullException(nameof(products));
            this.view = view ?? throw new ArgumentNullException(nameof(view));
        }            

        public void Execute()
        {
            view.DisplayProducts(productRepository.GetAll());
        }
    }
}