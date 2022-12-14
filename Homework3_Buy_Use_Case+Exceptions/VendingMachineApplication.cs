using System;
using System.Collections.Generic;
using System.Linq;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Exceptions;

namespace iQuest.VendingMachine
{
    internal class VendingMachineApplication
    {
        private readonly List<IUseCase> useCases;
        private readonly MainDisplay mainDisplay;

        private bool turnOffWasRequested;

        public bool UserIsLoggedIn { get; set; }

        public VendingMachineApplication(List<IUseCase> useCases, MainDisplay mainDisplay)
        {
            this.useCases = useCases ?? throw new ArgumentNullException(nameof(useCases));
            this.mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
        }

        public void Run()
        {
            turnOffWasRequested = false;

            while (!turnOffWasRequested)
            {
                
                try
                {
                    IEnumerable<IUseCase> availableUseCases = useCases
                    .Where(x => x.CanExecute);
                    IUseCase useCase = mainDisplay.ChooseCommand(availableUseCases);
                    useCase.Execute();

                }catch(CancelException e )
                {
                    Console.WriteLine(e.Message);
                }
                catch(Exception e){
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void TurnOff()
        {
            turnOffWasRequested = true;
        }
    }
}