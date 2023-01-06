using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Services;

namespace iQuest.VendingMachine.UseCases
{
    internal class TurnOffUseCase : IUseCase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly ITurnOffService turnOffSerivce;

        public string Name => "exit";

        public string Description => "Go to live your life.";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public TurnOffUseCase(ITurnOffService turnOffSerivce, IAuthenticationService authenticationService)
        {
            this.turnOffSerivce = turnOffSerivce ?? throw new ArgumentNullException(nameof(turnOffSerivce));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            turnOffSerivce.TurnOff();
        }
    }
}