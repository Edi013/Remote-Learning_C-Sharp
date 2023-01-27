using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Services;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace VM_UnitTests.UseCasesTests
{
    public class BuyUseCaseConstructorTests
    {
        private  ProductRepository productRepository;
        private  AuthenticationService authenticationService;
        private  BuyView buyView;

        [Fact]
        public void HavingAllArgumentsInOrder_ThanNameAndDescriptionAreInOrder()
        {
            string nameText = "Buy";
            string descriptionText = "You will buy something.";

            buyView = new BuyView();
            authenticationService = new AuthenticationService();
            productRepository = new ProductRepository();
            Mock<IPaymentUseCase> paymentUseCase = new Mock<IPaymentUseCase>();

            BuyUseCase buyUseCase = new BuyUseCase(buyView, authenticationService, productRepository, paymentUseCase.Object);
            Assert.Equal(nameText, buyUseCase.Name);
            Assert.Equal(descriptionText, buyUseCase.Description);
        }

        [Fact]
        public void HavingOneArgumentNull_ThrowsException()
        {
            List<IPaymentAlgorithm> paymentAlgorithms = new List<IPaymentAlgorithm>()
            {
            };
            IPaymentUseCase paymentUseCase = new PaymentUseCase(buyView, paymentAlgorithms);

            buyView = null;
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(buyView, authenticationService, productRepository, paymentUseCase));
            buyView = new BuyView();

            authenticationService = null;
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(buyView, authenticationService, productRepository, paymentUseCase));
            authenticationService = new AuthenticationService();

            productRepository = null;
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(buyView, authenticationService, productRepository, paymentUseCase));
            productRepository = new ProductRepository();

            paymentUseCase = null;
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(buyView, authenticationService, productRepository, paymentUseCase));
        }
    }
}
