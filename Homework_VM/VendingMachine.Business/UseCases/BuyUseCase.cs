using iQuest.VendingMachine.Business.Exceptions;

namespace iQuest.VendingMachine.Business
{
    public class BuyUseCase : IUseCase
    {
        private readonly IBuyView buyView;
        private readonly IPaymentUseCase paymentUseCase;
        private readonly IProductRepository productRepository;

        public BuyUseCase(
            IBuyView buyView, IAuthenticationService authenticationService,
            IProductRepository productRepository, IPaymentUseCase paymentUseCase
            )
        {
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
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
            if (wantedProduct.Quantity == 0)
            {
                throw new ProductNotAvailableException();
            }

            paymentUseCase.Execute(wantedProduct.Price);
            productRepository.DecreaseQuantity(wantedProduct);
            
            buyView.DispenseProduct(wantedProduct.Name);
        }
    }
}
