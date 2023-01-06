
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

            if(ValidateCardNumber(cardNumber))
                terminal.TransactionDone();
            else
                terminal.TransactionFailed();
        }

        private bool ValidateCardNumber(string userInput)
        {
            int cardNumberLength = userInput.Length;
            int sum = 0;
            bool parity = cardNumberLength % 2 == 0;
            
            int[] cardNumber = new int[cardNumberLength];
            for(int i = 0; i < cardNumberLength; i++)
                cardNumber[i] = int.Parse(Char.ToString(userInput[i]));

            for (int i = 0; i < cardNumberLength; i++)
            {
                if (i % 2 == 0)
                    sum = sum + cardNumber[i];
                else if (cardNumber[i] > 4)
                    sum += 2 * cardNumber[i] - 9;
                else
                    sum += 2 * cardNumber[i];
            }
            return sum % 10 == 0;
        }
    }
}
