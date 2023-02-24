namespace iQuest.VendingMachine.Business
{
    public class LogoutUseCase : IUseCase
    {
        private IAuthenticationService authenticationService;

        public string Name => "logout";

        public string Description => "Restrict access to administration buttons.";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public LogoutUseCase(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            authenticationService.Logout();
        }
    }
}
