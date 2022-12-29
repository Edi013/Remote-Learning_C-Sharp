using System.Collections.Generic;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.UseCases;
using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Services;
using iQuest.VendingMachine.Classes;

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
            ProductRepository productRepository = new ProductRepository();
            TurnOffWasRequestedChecker turnOffWasRequestedChecker = new TurnOffWasRequestedChecker();

            AuthenticationService authenticationService = new AuthenticationService();

            VendingMachineApplication vendingMachineApplication = new VendingMachineApplication(useCases, mainDisplay, turnOffWasRequestedChecker);
            
            ShelfView shelfView = new ShelfView();
            BuyView buyView = new BuyView();

            useCases.AddRange(new IUseCase[]
            {
                new LoginUseCase(mainDisplay, authenticationService),
                new LogoutUseCase(authenticationService),
                new TurnOffUseCase(turnOffWasRequestedChecker, authenticationService), 
                new LookUseCase(productRepository, shelfView),
                new BuyUseCase(buyView, authenticationService, productRepository)
            });

            return vendingMachineApplication;
        }
    }
}