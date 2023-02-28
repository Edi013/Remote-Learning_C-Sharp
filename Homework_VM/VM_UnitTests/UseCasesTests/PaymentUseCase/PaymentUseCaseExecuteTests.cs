using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.Business.Exceptions;
using Moq;

namespace VM_UnitTests.UseCasesTests
{
    public class PaymentUseCaseExecuteTests
    {
        private Mock<IBuyView> buyView;
        private Mock<List<IPaymentAlgorithm>> paymentAlgorithms;
        private readonly List<PaymentMethod> paymentMethods;
        private float priceForTest = 3.99f;



        public PaymentUseCaseExecuteTests()
        {
            this.buyView = new Mock<IBuyView>();
            this.paymentAlgorithms = new Mock<List<IPaymentAlgorithm>>();
            this.paymentMethods =
                new List<PaymentMethod>()
                {
                    new PaymentMethod(1, "Card"),
                    new PaymentMethod(2, "Cash")
                };
        }


        [Fact]
        public void ChoosingUnexistingPayingMethod_ThanExceptionThrown()
        {
            buyView
                .Setup(x => x.AskForPaymentMethod(paymentMethods))
                .Returns(3);

            var paymentUseCase = new PaymentUseCase(buyView.Object, paymentAlgorithms.Object);

            Assert.Throws<InvalidPaymentMethodException>(() => paymentUseCase.Execute(priceForTest));
        }

    }
}
