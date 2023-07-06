using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.Business.Exceptions;
using Moq;

namespace VM_UnitTests.UseCasesTests
{
    public class BuyUseCaseValidationTests
    {
        private readonly Mock<IProductAndSalesUnitOfWork> unitOfWork;
        private readonly Mock<IBuyView> buyView;
        private readonly Mock<IPaymentUseCase> paymentUseCase;

        public BuyUseCaseValidationTests()
        {
            unitOfWork = new Mock<IProductAndSalesUnitOfWork>();
            buyView = new Mock<IBuyView>();
            paymentUseCase = new Mock<IPaymentUseCase>();
        }

        [Fact]
        public void HavingNoAdminLoggedInAndNoProductsInRepository_ValidationTest1DoesNotPass()
        {
            BuyUseCase buyUseCase =
                new BuyUseCase(buyView.Object, paymentUseCase.Object, unitOfWork.Object);

            Product product = null;

            buyView
                .Setup(x => x.RequestProduct())
                .Returns(1);

            unitOfWork
                .Setup(x => x.ProductRepository.GetProductByColumnId(1))
                .Returns(product);

            Assert.Throws<InvalidColumnNumberException>(() => buyUseCase.Execute());
        }
    }
}

