﻿using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.DataAcces;
using iQuest.VendingMachine.Presentation;
using Moq;

namespace VM_UnitTests.UseCasesTests
{
    public class BuyUseCaseConstructorTests
    {
        private  IProductRepository productRepository;
        private  IAuthenticationService authenticationService;
        private  IBuyView buyView;

        [Fact]
        public void HavingAllArgumentsInOrder_ThanNameAndDescriptionAreInOrder()
        {
            string nameText = "Buy";
            string descriptionText = "You will buy something.";

            buyView = new BuyView();
            authenticationService = new AuthenticationService();
            productRepository = new InMemoryRepository();
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
            buyView = new BuyView();
            IPaymentUseCase paymentUseCase = new PaymentUseCase(buyView, paymentAlgorithms);

            buyView = null;
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(buyView, authenticationService, productRepository, paymentUseCase));
            buyView = new BuyView();

            authenticationService = null;
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(buyView, authenticationService, productRepository, paymentUseCase));
            authenticationService = new AuthenticationService();

            productRepository = null;
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(buyView, authenticationService, productRepository, paymentUseCase));
            productRepository = new InMemoryRepository();

            paymentUseCase = null;
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(buyView, authenticationService, productRepository, paymentUseCase));
        }
    }
}
