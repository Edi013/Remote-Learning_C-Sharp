using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.Presentation
{
    public class SupplyProductView : DisplayBase, ISupplyProductView
    {
        public Product RequestNewProduct()
        {
            DisplayLine("Input data for new product:", ConsoleColor.Cyan);

            var result = new Product();
            var properties = typeof(Product).GetProperties();
            foreach (var property in properties)
            {
                if (property.Name == "Id")
                    continue;

                DisplayLine($"Input {property.Name} as {property.DeclaringType}", ConsoleColor.Cyan);

                dynamic userInput;
                while (true)
                {
                    userInput = Console.ReadLine();

                    if (property.PropertyType == typeof(string))
                        break;
                    if (property.PropertyType == typeof(float))
                    {
                        float auxInput;
                        float.TryParse(userInput, out auxInput);
                        userInput = auxInput;
                        break;
                    }
                    if (property.PropertyType == typeof(int))
                    {
                        int auxInput;
                        int.TryParse(userInput, out auxInput);
                        userInput = auxInput;
                        break;
                    }
                    DisplayLine("Invalid data type.Try again.", ConsoleColor.Cyan);
                }

                property.SetValue(result, userInput);
            }
            return result;
        }

        public QuantitySupply RequestProductQuantity()
        {
            DisplayLine("Input data to supply a product:", ConsoleColor.Cyan);

            var quantitySupply = new QuantitySupply();
            var properties = typeof(QuantitySupply).GetProperties();

            foreach (var property in properties)
            {
                DisplayLine($"Input {property.Name} as {property.DeclaringType}", ConsoleColor.Cyan);

                dynamic userInput;
                while (true)
                {
                    userInput = Console.ReadLine();
                    if (property.PropertyType == typeof(int))
                    {
                        int auxInput;
                        int.TryParse(userInput, out auxInput);
                        userInput = auxInput;
                        break;
                    }
                    DisplayLine("Invalid data type. Try again.", ConsoleColor.Cyan);
                }

                property.SetValue(quantitySupply, userInput);
            }
            return quantitySupply;
        }
    }
}
