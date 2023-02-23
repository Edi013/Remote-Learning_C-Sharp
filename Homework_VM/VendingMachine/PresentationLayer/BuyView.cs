using iQuest.VendingMachine.UseCases;
using iQuest.VendingMachine.Exceptions;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class BuyView : DisplayBase, IBuyView
    {

        public int RequestProduct()
        {
            int columnNumber;

            Console.WriteLine();
            DisplayLine($"Type the column number of the desired product:", ConsoleColor.White);
            Console.WriteLine();

            string userInput = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(userInput))
            {
                throw new CancelException();
            }

            if(!int.TryParse(userInput, out columnNumber))
            {
                throw new InvalidInputException();
            }

            return columnNumber;
        }

        public void DispenseProduct(string productName)
        {
            Console.WriteLine();
            Console.WriteLine();
            DisplayLine($"Dispensing {productName}" , ConsoleColor.White);
            Console.WriteLine();
        }

        public int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods)
        {
            int paymentMethodNumber;

            Console.WriteLine();
            DisplayLine($"Pick the number of desired payment method:", ConsoleColor.White);
            foreach(PaymentMethod method in paymentMethods)
            {
                DisplayLine($"{method.Name}: {method.Id}", ConsoleColor.White);
            }
            Console.WriteLine();

            string userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                throw new CancelException();
            }
            if (!int.TryParse(userInput, out paymentMethodNumber))
            {
                throw new InvalidInputException();
            }

            return paymentMethodNumber;
        }
    }
}