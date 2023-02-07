using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Services;
using iQuest.VendingMachine.UseCases;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_UnitTests.UseCasesTests
{
    public class BuyUseCaseExecuteTests
    {
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<IBuyView> buyView;
        private readonly Mock<IPaymentUseCase> paymentUseCase;



        public BuyUseCaseExecuteTests()
        {
            productRepository = new Mock<IProductRepository>();
            authenticationService = new Mock<IAuthenticationService>();
            buyView = new Mock<IBuyView>();
            paymentUseCase = new Mock<IPaymentUseCase>();
        }

        [Fact]
        public void HavingProductAvailable_WithPositiveQuantity_ExecuteIsSuccesful()
        {
            //Arrange
            buyView
                .Setup(x => x.RequestProduct())
                .Returns(1);

            Product testProduct = new Product(1, "testProduct", 5.22f, 5);
            productRepository
                .Setup(x => x.GetProductByColumnId(1))
                .Returns(testProduct);


            BuyUseCase buyUseCase = new BuyUseCase(buyView.Object, authenticationService.Object, productRepository.Object, paymentUseCase.Object);
            
            //Act
            buyUseCase.Execute();

            //Assert
            Assert.Equal(4, testProduct.Quantity);
        }

        [Fact]
        public void HavingProductAvailable_WithZeroQuantity_ExecuteThrowsException()
        {
            //Arrange
            buyView
                .Setup(x => x.RequestProduct())
                .Returns(1);

            Product testProduct = new Product(1, "testProduct", 5.22f, 0);
            productRepository
                .Setup(x => x.GetProductByColumnId(1))
                .Returns(testProduct);


            BuyUseCase buyUseCase =
                new BuyUseCase(buyView.Object, authenticationService.Object, productRepository.Object, paymentUseCase.Object);

            //Act
            //Assert
            Assert.Throws<ProductNotAvailableException>(() => buyUseCase.Execute());
        }

        [Fact]
        public void HavingNoProductAvailable_ExecuteThrowsException()
        {
            //Arrange
            buyView
                .Setup(x => x.RequestProduct())
                .Returns(1);

            Product testProduct = null;
            productRepository
                .Setup(x => x.GetProductByColumnId(1))
                .Returns(testProduct);


            BuyUseCase buyUseCase =
                new BuyUseCase(buyView.Object, authenticationService.Object, productRepository.Object, paymentUseCase.Object);

            //Act
            //Assert
            Assert.Throws<InvalidColumnNumberException>(() => buyUseCase.Execute());
        }
    }
}
