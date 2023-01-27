using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace VM_UnitTests.UseCasesTests
{
    public class CardPaymentValidateCardNumberTests
    {
        private Mock<ICardPaymentTerminal> terminal;
        private CardPayment cardPayment;
        private string validCardNumber = "4012888888881881";

        public CardPaymentValidateCardNumberTests()
        {
            terminal = new Mock<ICardPaymentTerminal>();
            cardPayment = new CardPayment(terminal.Object); 
        }

        [Fact]
        public void HavingAGoodCardNumber_ThanReturnsTrue()
        {
            Assert.True(cardPayment.validator.ValidateCardNumber(validCardNumber));
        }
        [Fact]
        public void HavingABadCardNumber_ThanReturnsFalse()
        {
            Assert.False(cardPayment.validator.ValidateCardNumber("11"));
        }
    }
}
