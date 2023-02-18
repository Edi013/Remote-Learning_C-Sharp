using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Services;
using iQuest.VendingMachine.UseCases;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iQuest.VendingMachine.UseCases;

namespace VM_UnitTests.UseCasesTests
{
    public class BuyUseCaseCanExecuteTests
    {
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<IBuyView> buyView;
        private readonly Mock<IPaymentUseCase> paymentUseCase;

        public BuyUseCaseCanExecuteTests()
        {
            productRepository = new Mock<IProductRepository>();
            authenticationService = new Mock<IAuthenticationService>();
            buyView = new Mock<IBuyView>();
            paymentUseCase = new Mock<IPaymentUseCase>();
        }

        [Fact]
        public void HavingNoAdminLoggedInAndProductsInRepository_CanExecuteIsTrue()
        {
            List<Product> products = new List<Product>()
            {
                new Product(1, "testProduct", 3.33f, 3)
            };
            productRepository
                .Setup(x => x.GetProducts())
                .Returns(products);

            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(false);
            BuyUseCase buyUseCase =
                new BuyUseCase(buyView.Object, authenticationService.Object, productRepository.Object, paymentUseCase.Object);

            Assert.True(buyUseCase.CanExecute);
        }

        [Fact]
        public void HavingNoAdminLoggedInAndNoProductsInRepository_CanExecuteIsTrue()
        {
            List<Product> products = new List<Product>()
            {
            };
            productRepository
                .Setup(x => x.GetProducts())
                .Returns(products);

            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(false);
            BuyUseCase buyUseCase =
                new BuyUseCase(buyView.Object, authenticationService.Object, productRepository.Object, paymentUseCase.Object);

            Assert.False(buyUseCase.CanExecute);
        }

        [Fact]
        public void HavingAdminLoggedInAndProductsInRepository_CanExecuteIsFalse()
        {
            List<Product> products = new List<Product>()
            {
                new Product(1, "testProduct", 3.33f, 3)
            };
            productRepository
                .Setup(x => x.GetProducts())
                .Returns(products);
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(true);
            BuyUseCase buyUseCase =
                new BuyUseCase(buyView.Object, authenticationService.Object, productRepository.Object, paymentUseCase.Object);

            Assert.False(buyUseCase.CanExecute);
        }

        [Fact]
        public void HavingAdminLoggedInAndNoProductsInRepository_CanExecuteIsFalse()
        {
            List<Product> products = new List<Product>()
            {
            };
            productRepository
                .Setup(x => x.GetProducts())
                .Returns(products);

            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(true);
            BuyUseCase buyUseCase =
                new BuyUseCase(buyView.Object, authenticationService.Object, productRepository.Object, paymentUseCase.Object);

            Assert.False(buyUseCase.CanExecute);
        }
    }
}
