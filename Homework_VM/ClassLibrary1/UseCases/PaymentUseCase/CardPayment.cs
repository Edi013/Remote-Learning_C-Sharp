
namespace iQuest.VendingMachine.Business
{
    public class CardPayment : IPaymentAlgorithm
    {
        private readonly ICardPaymentTerminal terminal;
        public readonly CardValidator validator;
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
