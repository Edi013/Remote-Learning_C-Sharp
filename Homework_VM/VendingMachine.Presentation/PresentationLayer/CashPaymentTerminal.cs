using iQuest.VendingMachine.Exceptions;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CashPaymentTerminal : ICashPaymentTerminal
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
                throw new InvalidPaymentInputException();

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
