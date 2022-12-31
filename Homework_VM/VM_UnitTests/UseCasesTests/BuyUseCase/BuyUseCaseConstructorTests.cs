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

namespace VM_UnitTests.UseCasesTests
{
    public class BuyUseCaseConstructorTests
    {
        private  ProductRepository productRepository;
        private  AuthenticationService authenticationService;
        private  BuyView buyView;


       /* public BuyUseCaseConstructorTests()
        {
            productRepository = new ProductRepository();
            authenticationService = new AuthenticationService();
            buyView = new BuyView();
        }*/

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
            productRepository = new ProductRepository();
        }

    }
}
