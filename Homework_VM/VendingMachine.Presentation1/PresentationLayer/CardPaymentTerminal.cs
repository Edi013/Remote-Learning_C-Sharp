using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.Business.Exceptions;

namespace iQuest.VendingMachine.Presentation
{
    public class CardPaymentTerminal : ICardPaymentTerminal
    {
        public string AskForCardNumber()
        {
            string userInput;

            Console.WriteLine();
            Console.WriteLine("Waiting for card number");
            Console.WriteLine();

            userInput = Console.ReadLine();
            if (String.IsNullOrEmpty(userInput))
                throw new CancelException();

            return userInput;
        }
        public void TransactionDone()
        {
            Console.WriteLine();
            Console.WriteLine("Transaction done!");
            Console.WriteLine();
        }
        public void TransactionFailed()
        {
            Console.WriteLine();
            Console.WriteLine("Transaction failed!");
            Console.WriteLine();
            throw new InvalidCardNumberException();
        }
    }
}
