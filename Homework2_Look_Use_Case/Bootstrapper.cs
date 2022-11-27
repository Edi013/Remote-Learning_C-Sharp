using System.Collections.Generic;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.UseCases;
using iQuest.VendingMachine.DataLayer;

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
            MainDisplay mainDisplay = new MainDisplay();
            List<IUseCase> useCases = new List<IUseCase>();
            ProductRepository Stock = new ProductRepository();
            VendingMachineApplication vendingMachineApplication = new VendingMachineApplication(useCases, mainDisplay);

            useCases.AddRange(new IUseCase[]
            {
                new LoginUseCase(vendingMachineApplication, mainDisplay),
                new LogoutUseCase(vendingMachineApplication),
                new TurnOffUseCase(vendingMachineApplication),
                new LookUseCase(vendingMachineApplication)
            });

            return vendingMachineApplication;
        }
    }
}