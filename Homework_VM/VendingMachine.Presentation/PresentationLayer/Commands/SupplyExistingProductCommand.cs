using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.Presentation
{
    public class SupplyExistingProductCommand : ICommand
    {
        private readonly IAuthenticationService authenticationService;
        private IUseCaseFactory factory;

        public string Name => "Update";
        public string Description => "Update quantity of a product ( supply existing product )";
        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public SupplyExistingProductCommand(IUseCaseFactory factory, IAuthenticationService authenticationService)
        {
            this.factory = factory;
            this.authenticationService = authenticationService;
        }
        public void Execute()
        {
            var useCase = factory.Create<SupplyExistingProductUseCase>();
            useCase.Execute();
        }
    }
}
