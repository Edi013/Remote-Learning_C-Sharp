using System;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Classes;

namespace iQuest.VendingMachine.UseCases 
{
    internal class LoginUseCase : IUseCase
    {
        private readonly MainDisplay mainDisplay;
        AuthenticationService authenticationService;

        public string Name => "login";

        public string Description => "Get access to administration buttons.";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public LoginUseCase( MainDisplay mainDisplay, AuthenticationService authenticationService)
        {
            this.mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
            this.authenticationService = authenticationService;
        }

        public void Execute()
        {
            authenticationService.Login(mainDisplay.AskForPassword());
        }
    }
}