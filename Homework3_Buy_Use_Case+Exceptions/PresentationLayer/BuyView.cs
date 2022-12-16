using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Exceptions;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class BuyView : DisplayBase
    {

        public int RequestProduct()
        {
            int columnNumber;
            int minColumnNumber = ProductRepository.MinColumnNumber();
            int maxColumnNumber = ProductRepository.MaxColumnNumber();

            Console.WriteLine();
            Console.WriteLine();
            DisplayLine($"Type the column number of the desired product: ({minColumnNumber} - {maxColumnNumber})",
                ConsoleColor.White);
            Console.WriteLine();
            
            string userInput= Console.ReadLine();

            if(userInput == "")
            {
                throw new CancelException();
            }
            if(int.TryParse(userInput, out columnNumber))
            {
                if(columnNumber < minColumnNumber || columnNumber > maxColumnNumber)
                {
                    throw new InvalidColumnNumberException();
                }
            }
            else
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
        
    }
}