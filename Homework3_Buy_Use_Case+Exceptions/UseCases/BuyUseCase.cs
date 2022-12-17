using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Exceptions;

namespace iQuest.VendingMachine.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private readonly VendingMachineApplication vendingMachine;
        private readonly ProductRepository productRepository;
        private readonly BuyView buyView;

        public string Name => "Buy";

        public string Description => "You will buy something.";

        public bool CanExecute => productRepository.GetAll().Any() && !vendingMachine.UserIsLoggedIn;

        public BuyUseCase(VendingMachineApplication vendingMachine, ProductRepository products, BuyView buyView)
        {
            this.vendingMachine = vendingMachine;
            this.productRepository = products;
            this.buyView = buyView;
        }            

        public void Execute()
        { 
            int columnNumber = buyView.RequestProduct();

            Product? wantedProduct = productRepository.GetProductByColumnId(columnNumber);

            if(wantedProduct != null)
            {
                if(wantedProduct.Quantity > 0)
                {
                    //pay
                    wantedProduct.Quantity--;
                    buyView.DispenseProduct(wantedProduct.Name);
                }
                else
                {
                    throw new ProductNotAvailableException();
                }
            }
            else
            {
                throw new InvalidColumnNumberException();
            }
            
        }
    }
}