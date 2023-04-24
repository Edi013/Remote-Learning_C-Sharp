using iQuest.VendingMachine.Business.Exceptions;

namespace iQuest.VendingMachine.Business
{
    public class BuyUseCase : IUseCase
    {
        private readonly IBuyView buyView;
        private readonly IPaymentUseCase paymentUseCase;
        private readonly IProductRepository productRepository;
        private readonly ISaleRepository saleRepository;

        public BuyUseCase(
            IBuyView buyView, IProductRepository productRepository,
            IPaymentUseCase paymentUseCase, ISaleRepository saleRepository
            )
        {
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.paymentUseCase = paymentUseCase ?? throw new ArgumentNullException(nameof(paymentUseCase));
            this.saleRepository = saleRepository ?? throw new ArgumentNullException(nameof(saleRepository));
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

            saleRepository.Add(new Sale()
            {
                ProductName = wantedProduct.Name,
                Price = (decimal)wantedProduct.Price,
                Date = DateTime.Now,
                PaymentMethod = paymentUseCase.Name
            });
            buyView.DispenseProduct(wantedProduct.Name);
        }
    }
}
