using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Exceptions;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class BuyView : DisplayBase
    {
        private const string messageInvalidColumnNumber = "Such column number do not exist!";
        private const string messageProductNotAvailable = "Selected product is not available!";
        private const string messageInvalidInput = "Invalid input!";
        private const string messageCancelCommand = "Cancelling command ...";

        public int RequestProduct()
        {
            int columnNumber;
            int minColumnNumber = ProductRepository.MinColumnNumber();
            int maxCOlumnNumber = ProductRepository.MaxColumnNumber();

            Console.WriteLine();
            Console.WriteLine();
            DisplayLine($"Type the column number of the desired product: ({minColumnNumber} - {maxCOlumnNumber})",
                ConsoleColor.White);
            Console.WriteLine();
            
            while(true)
            {
                string userInput= Console.ReadLine();

                if(userInput == "")
                {
                    throw new CancelException(messageCancelCommand);
                }
                if(int.TryParse(userInput, out columnNumber))
                {
                    if(columnNumber < minColumnNumber || columnNumber > maxCOlumnNumber)
                    {
                    DisplayLine(messageInvalidColumnNumber, ConsoleColor.Red);
                        continue;
                    }
                    break;
                }
                else
                    DisplayLine(messageInvalidInput, ConsoleColor.Red);
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
        
        public void DisplayProductNotAvailabel()
        {
            DisplayLine(messageProductNotAvailable ,ConsoleColor.White);
        }
    }
}