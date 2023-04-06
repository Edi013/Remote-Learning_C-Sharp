using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.Presentation
{
    public class LookCommand : ICommand
    {
        private readonly IProductRepository productRepository;
        private IUseCaseFactory factory;

        public string Name => "See products";

        public string Description => "This is our stock.";
        public bool CanExecute => productRepository.GetProducts().Any();


        public LookCommand(IUseCaseFactory factory, IProductRepository productRepository)
        {
            this.factory = factory;
            this.productRepository = productRepository;
        }

        public void Execute()
        {
            var useCase = factory.Create<LookUseCase>();
            useCase.Execute();
        }
    }
}
