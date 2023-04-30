using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.Presentation
{
    public class SupplyNewProductCommand : ICommand
    {
        private readonly IAuthenticationService authenticationService;
        private IUseCaseFactory factory;

        public string Name => "New";
        public string Description => "Adds new product or replace existing product ( supply new product )";
        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public SupplyNewProductCommand(IUseCaseFactory factory, IAuthenticationService authenticationService)
        {
            this.factory = factory;
            this.authenticationService = authenticationService;
        }
        public void Execute()
        {
            var useCase = factory.Create<SupplyNewProductUseCase>();
            useCase.Execute();
        }
    }
}
