using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.Presentation;

namespace VM_UnitTests.UseCasesTests
{
    public class PaymentUseCaseConstructorTests
    {
        private  IBuyView buyView;
        private  List<IPaymentAlgorithm> paymentAlgorithms;

        private string description = "Payment method";
        
        [Fact]
        public void HavingAllArgumentsInOrder_ThanNameAndDescriptionAreInOrder()
        {
            buyView = new BuyView();
            paymentAlgorithms = new List<IPaymentAlgorithm>();

            PaymentUseCase paymentUseCase = new PaymentUseCase(buyView, paymentAlgorithms);

            Assert.Equal(description, paymentUseCase.Description);
        }

        [Fact]
        public void HavingOneArgumentNull_ThrowsException()
        {
            buyView = null;
            Assert.Throws<ArgumentNullException>(() => new PaymentUseCase(buyView, paymentAlgorithms));
            buyView = new BuyView();

            paymentAlgorithms = null;
            Assert.Throws<ArgumentNullException>(() => new PaymentUseCase(buyView, paymentAlgorithms));
        }
    }
}
