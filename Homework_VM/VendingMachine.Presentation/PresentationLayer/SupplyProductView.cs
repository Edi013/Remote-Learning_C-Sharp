using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.Presentation
{
    public class SupplyProductView : ISupplyProductView
    {
        public Product RequestNewProduct()
        {
            Console.WriteLine("Input data for new product:");

            var result = new Product();
            var properties = typeof(Product).GetProperties();
            foreach (var property in properties)
            {
                Console.WriteLine($"Input {property.Name} as {property.DeclaringType}");

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
                    Console.WriteLine("Invalid data type. Try again.");
                }

                property.SetValue(result, userInput);
            }
            return result;
        }

        public QuantitySupply RequestProductQuantity()
        {
            Console.WriteLine("Input data to supply a product:");

            var quantitySupply = new QuantitySupply();
            var properties = typeof(QuantitySupply).GetProperties();

            foreach (var property in properties)
            {
                Console.WriteLine($"Input {property.Name} as {property.DeclaringType}");

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
                    Console.WriteLine("Invalid data type. Try again.");
                }

                property.SetValue(quantitySupply, userInput);
            }
            return quantitySupply;
        }
    }
}
