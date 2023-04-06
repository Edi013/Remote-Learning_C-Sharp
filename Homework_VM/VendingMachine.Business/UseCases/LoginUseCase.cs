namespace iQuest.VendingMachine.Business
{
    public class LoginUseCase : IUseCase
    {
        private readonly IMainDisplay mainDisplay;
        private readonly IAuthenticationService authenticationService;
 
        public LoginUseCase(IMainDisplay mainDisplay, IAuthenticationService authenticationService)
        {
            this.mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            authenticationService.Login(mainDisplay.AskForPassword());
        }
    }
}
