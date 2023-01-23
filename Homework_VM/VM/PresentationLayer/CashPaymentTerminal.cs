using iQuest.VendingMachine.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CashPaymentTerminal
    {
        public float AskForMoney(float price) 
        {
            float inputMoneySum;

            Console.WriteLine();
            Console.WriteLine($"Waiting for cash payment, you have to pay {price} more");
            Console.WriteLine();

            string userInput = Console.ReadLine();
            if (userInput == "")
                throw new CancelException();
            if (!float.TryParse(userInput, out inputMoneySum))
                throw new InvalidInputWhilePayingException();

            return inputMoneySum;
        }
        public void GiveBackChange(float change) 
        {
            Console.WriteLine();
            Console.WriteLine($"Releasing change {change}");
            Console.WriteLine();
        }
        public void ReleaseMoney(float amount)
        {
            Console.WriteLine();
            Console.WriteLine($"Your money will be released.");
            Console.WriteLine($"Releasing change {amount}");
            Console.WriteLine();
        }
    }
}
