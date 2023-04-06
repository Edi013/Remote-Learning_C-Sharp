using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.Presentation
{
    public class LogoutCommand : ICommand
    {
        private IAuthenticationService authenticationService;
        private IUseCaseFactory factory;

        public string Name => "logout";
        public string Description => "Restrict access to administration buttons.";
        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public LogoutCommand(IUseCaseFactory _factory, IAuthenticationService authenticationService)
        {
            this.factory = _factory;
            this.authenticationService = authenticationService;
        }

        public void Execute()
        {
            var useCase = factory.Create<LogoutUseCase>();
            useCase.Execute();
        }
    }
}
