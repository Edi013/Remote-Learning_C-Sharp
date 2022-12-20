using System;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Classes;


namespace iQuest.VendingMachine.UseCases
{
    internal class LogoutUseCase : IUseCase
    {
        private AuthenticationService authenticationService;

        public string Name => "logout";

        public string Description => "Restrict access to administration buttons.";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public LogoutUseCase(AuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            authenticationService.Logout();
        }
    }
}