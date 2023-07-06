using iQuest.VendingMachine.Business.Exceptions;

namespace iQuest.VendingMachine.Business
{
    public class BuyUseCase : IUseCase
    {
        private readonly IBuyView buyView;
        private readonly IPaymentUseCase paymentUseCase;
        private readonly IProductAndSalesUnitOfWork unitOfWork;

        public BuyUseCase(IBuyView buyView, IPaymentUseCase paymentUseCase, IProductAndSalesUnitOfWork unitOfWork)
        {
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.paymentUseCase = paymentUseCase ?? throw new ArgumentNullException(nameof(paymentUseCase));
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public void Execute()
        {
            int columnNumber = buyView.RequestProduct();

            Product? wantedProduct = unitOfWork.ProductRepository.GetProductByColumnId(columnNumber);
            if (wantedProduct == null)
            {
                throw new InvalidColumnNumberException();
            }
            if (wantedProduct.Quantity == 0)
            {
                throw new ProductNotAvailableException();
            }

            paymentUseCase.Execute(wantedProduct.Price);
            unitOfWork.ProductRepository.DecreaseQuantity(wantedProduct);

            unitOfWork.SaleRepository.Add(new Sale()
            {
                ProductName = wantedProduct.Name,
                Price = (decimal)wantedProduct.Price,
                Date = DateTime.Now,
                PaymentMethod = paymentUseCase.Name
            });
            buyView.DispenseProduct(wantedProduct.Name);

            unitOfWork.SaveChanges();
        }
    }
}
