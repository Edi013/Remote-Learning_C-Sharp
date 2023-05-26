using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.Business.Exceptions;
using iQuest.VendingMachine.Presentation;
using log4net;
using log4net.Repository;
using System.Linq;

namespace iQuest.VendingMachine
{
    internal class VendingMachineApplication
    {
        private readonly IEnumerable<ICommand> commands;
        private readonly IMainDisplay mainDisplay;
        private ITurnOffService turnOffWasRequestedChecker;
        private readonly ILog logger;

        public VendingMachineApplication(IEnumerable<ICommand> commands, IMainDisplay mainDisplay, ITurnOffService turnOffWasRequestedChecker)
        {
            this.commands = commands ?? throw new ArgumentNullException(nameof(commands));
            this.mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
            this.turnOffWasRequestedChecker = turnOffWasRequestedChecker ?? throw new ArgumentNullException(nameof(turnOffWasRequestedChecker));
            this.logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); //(typeof(VendingMachineApplication));
        }

        public void Run()
        {
            logger.Info("Application started");
            
            while (!turnOffWasRequestedChecker.Status)
            {
                try
                {
                    IEnumerable<ICommand> availableCommands =
                        commands.Where(command => command.CanExecute);
                    ICommand command = mainDisplay.ChooseCommand(availableCommands);
                    logger.Info($"Action '{command.Name}' performed.");
                    command.Execute();
                }
                catch (InvalidCardNumberException e)
                {
                    mainDisplay.DisplayLine(e.Message);
                    LogError(e);
                }
                catch (InvalidPaymentInputException e)
                {
                    mainDisplay.DisplayLine(e.Message);
                    LogError(e);
                }
                catch (CancelException e)
                {
                    mainDisplay.DisplayLine(e.Message);
                    LogError(e);
                }
                catch (InvalidColumnNumberException e)
                {
                    mainDisplay.DisplayLine(e.Message);
                    LogError(e);
                }
                catch (InvalidInputException e )
                {
                    mainDisplay.DisplayLine(e.Message);
                    LogError(e);
                }
                catch (ProductNotAvailableException e)
                {
                    mainDisplay.DisplayLine(e.Message);
                    LogError(e);
                }
                catch (InvalidPasswordException e)
                {
                    mainDisplay.DisplayLine(e.Message);
                    LogError(e);
                }
                catch (Exception e){
                    mainDisplay.DisplayLine(e.Message);
                    LogError(e);
                }
            }
            logger.Info("Application closed");
        }
        private void LogError(Exception e)
        {
            logger.Error(e.Message + "\n" + e.StackTrace + "\n" + e.InnerException);
        }
    }
}
