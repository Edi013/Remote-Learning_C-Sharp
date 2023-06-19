namespace iQuest.VendingMachine.Business
{
    public class ShutDownUseCase : IUseCase
    {
        private ITurnOffService turnOffService;
        private IMainDisplay mainDisplay;

        public ShutDownUseCase(ITurnOffService turnOffService, IMainDisplay mainDisplay)
        {
            this.turnOffService = turnOffService;
            this.mainDisplay = mainDisplay;
        }

        public void Execute()
        {
            turnOffService.TurnOff();
            mainDisplay.DisplayLine("Shutting down . . .");
        }
    }
}
