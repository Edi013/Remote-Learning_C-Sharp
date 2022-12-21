using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Classes;
using iQuest.VendingMachine.Services;

namespace iQuest.VendingMachine.UseCases
{
    internal class TurnOffUseCase : IUseCase
    {
        private readonly AuthenticationService authenticationService;
        private readonly TurnOffWasRequestedChecker turnOffWasRequestedChecker;

        public string Name => "exit";

        public string Description => "Go to live your life.";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public TurnOffUseCase(TurnOffWasRequestedChecker turnOffWasRequestedChecker, AuthenticationService authenticationService)
        {
            this.turnOffWasRequestedChecker = turnOffWasRequestedChecker;
            this.authenticationService = authenticationService;
        }

        public void Execute()
        {
            turnOffWasRequestedChecker.TurnOff();
        }
    }
}