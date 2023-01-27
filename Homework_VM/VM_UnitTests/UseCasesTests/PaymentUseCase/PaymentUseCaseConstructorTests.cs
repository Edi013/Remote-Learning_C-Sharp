using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_UnitTests.UseCasesTests
{
    public class PaymentUseCaseConstructorTests
    {
        private  IBuyView buyView;
        private  List<IPaymentAlgorithm> paymentAlgorithms;

        private string name = "pay";
        private string description = "Payment method";
        
        [Fact]
        public void HavingAllArgumentsInOrder_ThanNameAndDescriptionAreInOrder()
        {
            buyView = new BuyView();
            paymentAlgorithms = new List<IPaymentAlgorithm>();

            PaymentUseCase paymentUseCase = new PaymentUseCase(buyView, paymentAlgorithms);

            Assert.Equal(name, paymentUseCase.Name);
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
