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
        private readonly IPaymentUseCase paymentUseCase;

        public string Name => "Buy";

        public string Description => "You will buy something.";

        public bool CanExecute => productRepository.GetProducts().Any() && !authenticationService.IsUserAuthenticated; 

        public BuyUseCase(
            IBuyView buyView, IAuthenticationService authenticationService,
            IProductRepository productRepository, IPaymentUseCase paymentUseCase
            )
        {
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.paymentUseCase = paymentUseCase ?? throw new ArgumentNullException(nameof(paymentUseCase));
        }

        public void Execute()
        {
            int columnNumber = buyView.RequestProduct();    

            Product? wantedProduct = productRepository.GetProductByColumnId(columnNumber);
            if (wantedProduct == null)
            {
                throw new InvalidColumnNumberException();
            }
            if (wantedProduct.Quantity == 0 || wantedProduct.GetType() != typeof(Product))
            {
                throw new ProductNotAvailableException();
            }

            paymentUseCase.Execute(wantedProduct.Price);
            wantedProduct.Quantity--;
            buyView.DispenseProduct(wantedProduct.Name);
        }
    }
}