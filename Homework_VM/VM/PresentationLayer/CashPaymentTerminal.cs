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
            int inputMoneySum;

            Console.WriteLine();
            Console.WriteLine($"Waiting for cash payment, you have to pay {price} more");
            Console.WriteLine();

            inputMoneySum = int.Parse(Console.ReadLine());

            return inputMoneySum;
        }
        public void GiveBackChange(float change) 
        {
            Console.WriteLine();
            Console.WriteLine($"Releasing change {change}");
            Console.WriteLine();
        }
    }
}
