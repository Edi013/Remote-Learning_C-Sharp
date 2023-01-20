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
        private readonly PaymentUseCase paymentUseCase;

        public string Name => "Buy";

        public string Description => "You will buy something.";

        public bool CanExecute => productRepository.GetAll().Any() && !authenticationService.IsUserAuthenticated; 

        public BuyUseCase(
            IBuyView buyView, IAuthenticationService authenticationService,
            IProductRepository productRepository, PaymentUseCase paymentUseCase
            )
        {
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.paymentUseCase = paymentUseCase ?? throw new ArgumentNullException(nameof(paymentUseCase));
        }

        public void Execute()
        {
            try
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

                paymentUseCase.Execute(wantedProduct.Price);
                wantedProduct.Quantity--;
                buyView.DispenseProduct(wantedProduct.Name);
            }
            catch (InvalidColumnNumberException e)
            {
                Console.WriteLine("Invalid column number!");
            }
            catch (ProductNotAvailableException e)
            {
                Console.WriteLine("Product not available!");
            }
            catch (InvalidCardNumberException e)
            {
                Console.WriteLine("invalid card number");
            }
            catch (Exception e)
            {
                Console.WriteLine("payment service initilization error");
            }   
        }
    }
}