using System;
using System.Collections.Generic;
using System.Linq;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Services;


namespace iQuest.VendingMachine
{
    internal class VendingMachineApplication
    {
        private readonly List<IUseCase> useCases;
        private readonly MainDisplay mainDisplay;
        private TurnOffService turnOffWasRequestedChecker;
        public VendingMachineApplication(List<IUseCase> useCases, MainDisplay mainDisplay, TurnOffService turnOffWasRequestedChecker)
        {
            this.useCases = useCases ?? throw new ArgumentNullException(nameof(useCases));
            this.mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
            this.turnOffWasRequestedChecker = turnOffWasRequestedChecker ?? throw new ArgumentNullException(nameof(useCases));
        }

        public void Run()
        {
            while (!turnOffWasRequestedChecker.Status)
            {
                try
                {
                    IEnumerable<IUseCase> availableUseCases = useCases
                    .Where(x => x.CanExecute);
                    IUseCase useCase = mainDisplay.ChooseCommand(availableUseCases);
                    useCase.Execute();
                }
                catch (InvalidColumnNumberException e)
                {
                    Console.WriteLine("Invalid column number!");
                }
                catch (ProductNotAvailableException e)
                {
                    Console.WriteLine("Product not available!");
                }
                catch (InvalidCardNumberException e)
                {
                    Console.WriteLine("invalid card number");
                }
                catch (InvalidInputWhilePayingException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (CancelException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch(InvalidColumnNumberException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch(InvalidInputException e )
                {
                    Console.WriteLine(e.Message);
                }
                catch(ProductNotAvailableException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch(InvalidPasswordException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch(Exception e){
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}