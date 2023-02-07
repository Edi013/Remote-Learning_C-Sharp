using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.UseCases;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_UnitTests.UseCasesTests
{
    public class CashPaymentTests
    {
        private Mock<ICashPaymentTerminal> terminal;
        private CashPayment cashPayment;

        private float priceToPay = 5.99f;

        public CashPaymentTests()
        {
            this.terminal = new Mock<ICashPaymentTerminal>();
        }

        [Fact]
        public void WhilePaying_WithNonFloatInput_ThrowsException()
        {
            terminal
                .Setup(x => x.AskForMoney(priceToPay))
                .Throws(new InvalidPaymentInputException());
            cashPayment = new CashPayment(terminal.Object);

            Assert.Throws<InvalidPaymentInputException>(() => cashPayment.Run(priceToPay));
        }

        [Fact]
        public void WhilePaying_CommandIsCanceled_ThrowsException()
        {

            terminal
                .Setup(x => x.AskForMoney(priceToPay))
                .Throws(new CancelException());
            cashPayment = new CashPayment(terminal.Object);

            Assert.Throws<CancelException>(() => cashPayment.Run(priceToPay));
        }
    }
}
