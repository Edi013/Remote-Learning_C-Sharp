using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.Presentation
{
    public class ShutDownCommand : ICommand
    {
        private IAuthenticationService authenticationService;
        private IUseCaseFactory factory;

        public string Name => "Shutdown";
        public string Description => "Shut down the VM's OS";
        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public ShutDownCommand(IUseCaseFactory factory, IAuthenticationService authenticationService)
        {
            this.factory = factory;
            this.authenticationService = authenticationService;
        }

        public void Execute()
        {
            var useCase = factory.Create<ShutDownUseCase>();
            useCase.Execute();
        }
    }
}
