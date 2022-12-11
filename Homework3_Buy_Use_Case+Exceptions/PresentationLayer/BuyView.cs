using iQuest.VendingMachine.DataLayer;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class BuyView : DisplayBase
    {
        private const string messageInvalidColumnNumber = "Such column number do not exist!";
        private const string messageProductNotFound = "Selected product is not avalaible!";
        private const string messageInvalidInput = "Invalid input!";
        private const string messageCancelCommand = "Cancelling command . . .";

        public int RequestProduct()
        {
            int columnNumber;

            Console.WriteLine();
            Console.WriteLine();
            DisplayLine($"Type the column number of the desired product: ({ProductRepository.MinColumnNumber()} - {ProductRepository.MaxColumnNumber()})",
                ConsoleColor.White);
            Console.WriteLine();
            
            while(true)
            {
                string userInput= Console.ReadLine();

                if(userInput == "")
                {
                    DisplayLine(messageCancelCommand, ConsoleColor.White);
                    return -1;
                }
                if(int.TryParse(userInput, out columnNumber))
                {
                    if(columnNumber < ProductRepository.MinColumnNumber() || columnNumber > ProductRepository.MaxColumnNumber())
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
        
        public void DisplayProductNotFound()
        {
            DisplayLine(messageProductNotFound ,ConsoleColor.White);
        }

    }
}