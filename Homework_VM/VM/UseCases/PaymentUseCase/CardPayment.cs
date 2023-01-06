
using iQuest.VendingMachine.PresentationLayer;

namespace iQuest.VendingMachine.UseCases
{
    internal class CardPayment : IPaymentAlgorithm
    {
        private CardPaymentTerminal terminal;

        public string Name => "Card";

        public CardPayment() 
        {
            terminal = new CardPaymentTerminal();
        }

        public void Run(float price)
        {
            string cardNumber = terminal.AskForCardNumber();


            //validate card nr

            terminal.TransactionDone();
        }
    }
}
