using System.Configuration;
using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.DataAcces;
using iQuest.VendingMachine.Presentation;

namespace iQuest.VendingMachine
{
    internal class Bootstrapper
    {
        public void Run()
        {
            VendingMachineApplication vendingMachineApplication = BuildApplication();
            vendingMachineApplication.Run();
        }

        private static VendingMachineApplication BuildApplication()
        {
            List<IUseCase> useCases = new List<IUseCase>();
            MainDisplay mainDisplay = new MainDisplay();

            string _connectionString;

            IProductRepository productRepository = null;
            switch (ConfigurationManager.AppSettings["repoType"])
            {
                case "InMemory":
                    productRepository = new InMemoryRepository();
                    break;
                case "SQL":
                    _connectionString = 
                        ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
                    productRepository = new SqlServerRepository(_connectionString);
                    break;
                case "LiteDB":
                    _connectionString =
                        ConfigurationManager.ConnectionStrings["LiteDB"].ConnectionString;

                    productRepository = new LiteDBRepository(_connectionString);
                    break;
            }

            TurnOffService turnOffService = new TurnOffService();

            AuthenticationService authenticationService = new AuthenticationService();

            VendingMachineApplication vendingMachineApplication =
                new VendingMachineApplication(useCases, mainDisplay, turnOffService);
            
            ShelfView shelfView = new ShelfView();
            BuyView buyView = new BuyView();

            List<IPaymentAlgorithm> paymentAlgorithms = new List<IPaymentAlgorithm>
            {
                new CardPayment(new CardPaymentTerminal()),
                new CashPayment(new CashPaymentTerminal())
            };
            PaymentUseCase payment = new PaymentUseCase(buyView, paymentAlgorithms); 

            useCases.AddRange(new IUseCase[]
            {

                new LoginUseCase(mainDisplay, authenticationService),
                new LogoutUseCase(authenticationService),
                new TurnOffUseCase(turnOffService, authenticationService), 
                new LookUseCase(productRepository, shelfView),
                new BuyUseCase(buyView, authenticationService, productRepository, payment)
            });

            return vendingMachineApplication;
        }
    }
}
