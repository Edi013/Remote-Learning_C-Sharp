using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.PresentationLayer;

namespace iQuest.VendingMachine.UseCases
{
    internal class LookUseCase : IUseCase
    {
        private readonly VendingMachineApplication Application;
        private ProductRepository Stock;
        private readonly ShelfView View;
        public string Name => "Products: ";

        public string Description => "This is our stock as you see it.";

        public bool CanExecute => Stock.GetAll().Count() == 0;

        public LookUseCase(VendingMachineApplication application, ProductRepository stock, ShelfView view)
        {
            this.Application = application ?? throw new ArgumentNullException(nameof(application));
            this.Stock = stock ?? throw new ArgumentNullException(nameof(stock));
            this.View = view ?? throw new ArgumentNullException(nameof(view));
        }            

        public void Execute()
        {
            View.DisplayProducts(Stock.GetAll());
        }
    }
}