using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.Business.Exceptions;
using iQuest.VendingMachine.Presentation;

namespace iQuest.VendingMachine
{
    internal class VendingMachineApplication
    {
        private readonly IEnumerable<IUseCase> useCases;
        private readonly IMainDisplay mainDisplay;
        private ITurnOffService turnOffWasRequestedChecker;

        public VendingMachineApplication(IEnumerable<IUseCase> useCases, IMainDisplay mainDisplay, ITurnOffService turnOffWasRequestedChecker)
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
                catch (InvalidCardNumberException e)
                {
                    mainDisplay.DisplayLine(e.Message);
                }
                catch (InvalidPaymentInputException e)
                {
                    mainDisplay.DisplayLine(e.Message);
                }
                catch (CancelException e)
                {
                    mainDisplay.DisplayLine(e.Message);
                }
                catch (InvalidColumnNumberException e)
                {
                    mainDisplay.DisplayLine(e.Message);
                }
                catch (InvalidInputException e )
                {
                    mainDisplay.DisplayLine(e.Message);
                }
                catch (ProductNotAvailableException e)
                {
                    mainDisplay.DisplayLine(e.Message);
                }
                catch (InvalidPasswordException e)
                {
                    mainDisplay.DisplayLine(e.Message);
                }
                catch (Exception e){
                    mainDisplay.DisplayLine(e.Message);
                }
            }
        }
    }
}
