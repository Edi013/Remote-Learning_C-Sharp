using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Services;
using iQuest.VendingMachine.UseCases;

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

            BuyUseCase buyUseCase = new BuyUseCase(buyView, authenticationService, productRepository);
            Assert.Equal(nameText, buyUseCase.Name);
            Assert.Equal(descriptionText, buyUseCase.Description);
        }

        [Fact]
        public void HavingOneArgumentNull_ThrowsException()
        {
            buyView = null;
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(buyView, authenticationService, productRepository));
            buyView = new BuyView();

            authenticationService = null;
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(buyView, authenticationService, productRepository));
            authenticationService = new AuthenticationService();

            productRepository = null;
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(buyView, authenticationService, productRepository));
        }
    }
}
