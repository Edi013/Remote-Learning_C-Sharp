using System.Collections.Generic;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.UseCases;
using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Services;

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
            // #1 In memory ProductRepo
            //ProductRepositoryInMemory productRepository = new ProductRepositoryInMemory();

            // #2 SQL Server ProductRepo
            SqlServerRepository productRepository = SqlServerConnection.SetUp();
                // next line is just for testing the sql connection 
            productRepository.GetProducts().ForEach(p => Console.WriteLine($"{p.Name}, price: {p.Price}"));

            // #3
            // ----
            TurnOffService turnOffService = new TurnOffService();

            AuthenticationService authenticationService = new AuthenticationService();

            VendingMachineApplication vendingMachineApplication = new VendingMachineApplication(useCases, mainDisplay, turnOffService);
            
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