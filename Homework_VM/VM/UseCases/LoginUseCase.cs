using System;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Services;

namespace iQuest.VendingMachine.UseCases
{
    internal class LoginUseCase : IUseCase
    {
        private readonly IMainDisplay mainDisplay;
        private readonly IAuthenticationService authenticationService;

        public string Name => "login";

        public string Description => "Get access to administration buttons.";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

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