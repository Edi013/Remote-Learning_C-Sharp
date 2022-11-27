using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.PresentationLayer;

namespace iQuest.VendingMachine.UseCases
{
    internal class LookUseCase : IUseCase
    {
        private readonly VendingMachineApplication Application;
        private ProductRepository Stock;
        private ShelfView View;
        public string Name => "Products: ";

        public string Description => "This is our stock.";

        public bool CanExecute => throw new NotImplementedException();

        public LookUseCase(VendingMachineApplication application)
        {
            this.Application = application ?? throw new ArgumentNullException(nameof(application));
        }

        public void Execute()
        {
            View.DisplayProducts(Stock.ListOfProducts);
        }
    }
}