using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Services;

namespace iQuest.VendingMachine.UseCases
{
    internal class TurnOffUseCase : IUseCase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly ITurnOffService turnOffWasRequestedChecker;

        public string Name => "exit";

        public string Description => "Go to live your life.";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public TurnOffUseCase(ITurnOffService turnOffWasRequestedChecker, IAuthenticationService authenticationService)
        {
            this.turnOffWasRequestedChecker = turnOffWasRequestedChecker ?? throw new ArgumentNullException(nameof(turnOffWasRequestedChecker));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            turnOffWasRequestedChecker.TurnOff();
        }
    }
}