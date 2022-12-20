using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Classes;


namespace iQuest.VendingMachine.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private readonly VendingMachineApplication vendingMachine;
        private readonly ProductRepository productRepository;
        private readonly BuyView buyView;
        private LoginChecker loginChecker;

        public string Name => "Buy";

        public string Description => "You will buy something.";

        public bool CanExecute => productRepository.GetAll().Any() && !loginChecker.LoginStatus;

        public BuyUseCase(VendingMachineApplication vendingMachine, ProductRepository products, BuyView buyView, LoginChecker loginChecker)
        {
            this.vendingMachine = vendingMachine;
            this.productRepository = products;
            this.buyView = buyView;
            this.loginChecker = loginChecker;
        }            

        public void Execute()
        { 
            int columnNumber = buyView.RequestProduct();

            Product? wantedProduct = productRepository.GetProductByColumnId(columnNumber);

            if(wantedProduct == null)
            {
                throw new InvalidColumnNumberException();
            }
            if(wantedProduct.Quantity == 0)
            {
                throw new ProductNotAvailableException();
            }
                
            wantedProduct.Quantity--;
            buyView.DispenseProduct(wantedProduct.Name); 
        }
    }
}