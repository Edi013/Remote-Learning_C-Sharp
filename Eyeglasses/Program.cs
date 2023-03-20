using System.Reflection;
using iQuest.VendingMachine.Business;

namespace Program
{
    class LetsUseDLL
    {
        public static void Main()
        {

            var pathToAssembly = new FileInfo(@"VendingMachine.Business.dll");
            var bussinessAssembly = Assembly.LoadFile(pathToAssembly.FullName);

            //Let's find out what types does this dll uses:
            var definedTypesInAssembly = bussinessAssembly.DefinedTypes;

            int typesContor = 0;
            bool keepLoopOn = true;

            foreach (var item in definedTypesInAssembly)
            {
                Console.WriteLine("-------New Type-------");
                Console.WriteLine(item.Name +" " + item.Namespace);
                Console.WriteLine();


                var aType = bussinessAssembly.GetType($"{item.Namespace}.{item.Name}");
                try
                {
                    dynamic anObject = Activator.CreateInstance(aType);
                    Type parameterType = anObject.GetType();

                    Console.WriteLine("All interfaces");
                    foreach (MemberInfo member in parameterType.GetInterfaces()) // GetInterfaces
                        Console.WriteLine(member.Name);
                    Console.WriteLine(); 

                    Console.WriteLine("All private fields");
                    foreach (MemberInfo member in parameterType.GetFields
                        (BindingFlags.NonPublic | BindingFlags.Instance))
                            Console.WriteLine(member.Name);
                    Console.WriteLine();

                    Console.WriteLine("All public fields");
                    foreach (MemberInfo member in parameterType.GetFields())
                        Console.WriteLine(member.Name);
                    Console.WriteLine();

                    Console.WriteLine("All public Methods");
                    foreach (MemberInfo member in parameterType.GetMethods())
                        Console.WriteLine(member.Name);
                    Console.WriteLine();

                    Console.WriteLine("All public properties");
                    foreach (MemberInfo member in parameterType.GetProperties())
                        Console.WriteLine(member.Name);
                    Console.WriteLine();

                }
                catch (System.MissingMethodException)
                {
                    Console.WriteLine($"Type cannot be instantiated");
                }

                typesContor++;
                if (typesContor % 30 == 0)
                    keepLoopOn = AskToContinue();
                if (!keepLoopOn)
                    break;

            }
            Console.ReadLine();

            bool AskToContinue()
            {
                while (true)
                {
                    Console.WriteLine("Do you want to see another types ? Type Y/N");

                    var userInput = Console.ReadLine();

                    if (userInput.Length > 1)
                    {
                        Console.WriteLine("Answer with Y/N");
                        continue;
                    }

                    switch (userInput.ToUpper())
                    {
                        case "Y":
                            return true;
                        case "N":
                            return false;
                    }
                }
            }
        }
    }
}


//EmbeddedAttribute Microsoft.CodeAnalysis
//NullableAttribute System.Runtime.CompilerServices
//NullableContextAttribute System.Runtime.CompilerServices
//IProductRepository iQuest.VendingMachine.Business
//Product iQuest.VendingMachine.Business
//IBuyView iQuest.VendingMachine.Business
//ICardPaymentTerminal iQuest.VendingMachine.Business
//ICashPaymentTerminal iQuest.VendingMachine.Business
//IMainDisplay iQuest.VendingMachine.Business
//IShelfView iQuest.VendingMachine.Business
//AuthenticationService iQuest.VendingMachine.Business
//IAuthenticationService iQuest.VendingMachine.Business
//ITurnOffService iQuest.VendingMachine.Business
//TurnOffService iQuest.VendingMachine.Business
//BuyUseCase iQuest.VendingMachine.Business
//IUseCase iQuest.VendingMachine.Business
//LoginUseCase iQuest.VendingMachine.Business
//LogoutUseCase iQuest.VendingMachine.Business
//LookUseCase iQuest.VendingMachine.Business
//CardPayment iQuest.VendingMachine.Business
//CardValidator iQuest.VendingMachine.Business
//CashPayment iQuest.VendingMachine.Business
//IPaymentAlgorithm iQuest.VendingMachine.Business
//IPaymentUseCase iQuest.VendingMachine.Business
//PaymentMethod iQuest.VendingMachine.Business
//PaymentUseCase iQuest.VendingMachine.Business
//TurnOffUseCase iQuest.VendingMachine.Business
//CancelException iQuest.VendingMachine.Business.Exceptions
//InvalidCardNumberException iQuest.VendingMachine.Business.Exceptions
//InvalidColumnNumberException iQuest.VendingMachine.Business.Exceptions
//InvalidInputException iQuest.VendingMachine.Business.Exceptions
//InvalidPasswordException iQuest.VendingMachine.Business.Exceptions
//InvalidPaymentInputException iQuest.VendingMachine.Business.Exceptions
//InvalidPaymentMethodException iQuest.VendingMachine.Business.Exceptions
//ProductNotAvailableException iQuest.VendingMachine.Business.Exceptions
