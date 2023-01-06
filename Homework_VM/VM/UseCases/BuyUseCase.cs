using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Services;

namespace iQuest.VendingMachine.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly IBuyView buyView;
        private readonly IAuthenticationService authenticationService;

        public string Name => "Buy";

        public string Description => "You will buy something.";

        public bool CanExecute => productRepository.GetAll().Any() && !authenticationService.IsUserAuthenticated; 

        public BuyUseCase(IBuyView buyView, IAuthenticationService authenticationService, IProductRepository productRepository)
        {
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public void Execute()
        { 
            int columnNumber = buyView.RequestProduct();    

            Product? wantedProduct = productRepository.GetProductByColumnId(columnNumber);
            if (wantedProduct == null)
            {
                throw new InvalidColumnNumberException();
            }
            if (wantedProduct.Quantity == 0)
            {
                throw new ProductNotAvailableException();
            }

            try
            {
                PaymentUseCase payment = new PaymentUseCase(buyView, authenticationService);
                payment.Execute(wantedProduct.Price);

                wantedProduct.Quantity--;
                buyView.DispenseProduct(wantedProduct.Name);
            }
            catch (InvalidCardNumberException e)
            {
                Console.WriteLine("invalid card number");
            }
            catch (Exception e)
            {
                Console.WriteLine("payment service initilization erro");
            }   
        }
    }
}