using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.DataAcces;
using iQuest.VendingMachine.DataAccess;
using iQuest.VendingMachine.Presentation;
using Moq;

namespace VM_UnitTests.UseCasesTests
{
    public class BuyUseCaseConstructor
    {
        private IProductAndSalesUnitOfWork unitOfWork;
        private IAuthenticationService authenticationService;
        private IBuyView buyView;

        public BuyUseCaseConstructor()
        {
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
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(buyView, paymentUseCase, unitOfWork));
            buyView = new BuyView();

            authenticationService = null;
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(buyView, paymentUseCase, unitOfWork));
            authenticationService = new AuthenticationService();

            unitOfWork = null;
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(buyView, paymentUseCase, unitOfWork));
            
            /* // #To test creation of object
            IProductRepository productRepo = new EfProductRepository(context);
            ISaleRepository salesRepo = new EfSalesRepository(context);
            unitOfWork = new EfUnitOfWork(productRepo, salesRepo, context);

            Assert.NotNull(new BuyUseCase(buyView, paymentUseCase, unitOfWork));*/
        }
    }
}


