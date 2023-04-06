using System;
using System.Collections.Generic;
using System.Linq;
using iQuest.VendingMachine.Business;
using Autofac;
using iQuest.VendingMachine;

namespace iQuest.VendingMachine.Presentation
{
    public class LoginCommand : ICommand
    {
        private readonly IAuthenticationService authenticationService;
        private IUseCaseFactory factory;
        public string Name => "login";
        public string Description => "Get access to administration buttons.";
        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public LoginCommand(IUseCaseFactory _factory, IAuthenticationService authenticationService)
        {
            this.factory = _factory;
            this.authenticationService = authenticationService;
        }

        public void Execute()
        {
            var useCase = factory.Create<LoginUseCase>();
            useCase.Execute();
        }
    }
}
