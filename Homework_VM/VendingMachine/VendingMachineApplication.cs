using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.Business.Exceptions;
using iQuest.VendingMachine.DataAccess;

namespace iQuest.VendingMachine
{
    internal class VendingMachineApplication
    {
        private readonly IEnumerable<ICommand> commands;
        private readonly IMainDisplay mainDisplay;
        private ITurnOffService turnOffWasRequestedChecker;

        public VendingMachineApplication(IEnumerable<ICommand> commands, IMainDisplay mainDisplay, ITurnOffService turnOffWasRequestedChecker)
        {
            this.commands = commands ?? throw new ArgumentNullException(nameof(commands));
            this.mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
            this.turnOffWasRequestedChecker = turnOffWasRequestedChecker ?? throw new ArgumentNullException(nameof(turnOffWasRequestedChecker));
        }

        public void Run()
        {
            while (!turnOffWasRequestedChecker.Status)
            {
                try
                {
                    IEnumerable<ICommand> availableCommands =
                        commands.Where(command => command.CanExecute);
                    ICommand command = mainDisplay.ChooseCommand(availableCommands);
                    command.Execute();
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
