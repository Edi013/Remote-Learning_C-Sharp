using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CardPaymentTerminal
    {
        public string AskForCardNumber()
        {
            string userInput;

            Console.WriteLine();
            Console.WriteLine("Waiting for card number");
            Console.WriteLine();

            userInput = Console.ReadLine();

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
