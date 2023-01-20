
using iQuest.VendingMachine.PresentationLayer;

namespace iQuest.VendingMachine.UseCases
{
    internal class CardPayment : IPaymentAlgorithm
    {
        private ICardPaymentTerminal terminal;
        private CardValidator validator;
        public string Name => "Card";

        public CardPayment(ICardPaymentTerminal terminal) 
        {
            this.terminal = terminal;
            this.validator = new CardValidator();

        }

        public void Run(float price)
        {
            string cardNumber = terminal.AskForCardNumber();

            if(validator.ValidateCardNumber(cardNumber))
                terminal.TransactionDone();
            else
                terminal.TransactionFailed();
        }

 
    }
}
