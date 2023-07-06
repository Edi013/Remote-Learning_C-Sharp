using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.Business.Exceptions;
using Moq;

namespace VM_UnitTests.UseCasesTests
{
    public class BuyUseCaseExecuteTests
    {
        private readonly Mock<IProductAndSalesUnitOfWork> unitOfWork;
        private readonly Mock<IBuyView> buyView;
        private readonly Mock<IPaymentUseCase> paymentUseCase;

        public BuyUseCaseExecuteTests()
        {
            unitOfWork = new Mock<IProductAndSalesUnitOfWork>();
            buyView = new Mock<IBuyView>();
            paymentUseCase = new Mock<IPaymentUseCase>();
        }

        [Fact]
        public void HavingProductAvailable_WithPositiveQuantity_ExecuteIsSuccesful()
        {
            BuyUseCase buyUseCase =
                new BuyUseCase(buyView.Object, paymentUseCase.Object, unitOfWork.Object);

            Product product = new Product(1, "testProduct", 3.33f, 3);

            buyView
                .Setup(x => x.RequestProduct())
                .Returns(1);

            unitOfWork
                .Setup(x => x.ProductRepository.GetProductByColumnId(1))
                .Returns(product);

            var paymentMethods =
                new List<PaymentMethod>()
                {
                    new PaymentMethod(1, "Card"),
                    new PaymentMethod(2, "Cash")
                };
            buyView
                .Setup(x => x.AskForPaymentMethod(paymentMethods))
                .Returns(3);

            unitOfWork
                .Setup(x => x.ProductRepository.DecreaseQuantity(product))
                .Callback(() => product.Quantity--);

            unitOfWork
                .Setup(x => x.SaleRepository.Add(new Sale()));

            buyUseCase.Execute();

            Assert.True(product.Quantity == 2);
        }


        [Fact]
        public void HavingProductAvailable_WithNullQuantity_ExecuteThrowsException()
        {
            BuyUseCase buyUseCase =
                new BuyUseCase(buyView.Object, paymentUseCase.Object, unitOfWork.Object);

            Product product = new Product(1, "testProduct", 3.33f, 0);

            buyView
                .Setup(x => x.RequestProduct())
                .Returns(1);

            unitOfWork
                .Setup(x => x.ProductRepository.GetProductByColumnId(1))
                .Returns(product);

            Assert.Throws<ProductNotAvailableException>(() => buyUseCase.Execute());
        }
    }
}

