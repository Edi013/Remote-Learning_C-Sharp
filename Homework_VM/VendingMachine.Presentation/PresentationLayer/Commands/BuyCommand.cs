using System;
using System.Collections.Generic;
using System.Linq;
using iQuest.VendingMachine.Business;
using Autofac;
using iQuest.VendingMachine;

namespace iQuest.VendingMachine.Presentation
{
    public class BuyCommand : ICommand
    {
        private readonly IProductRepository productRepository;
        private readonly IAuthenticationService authenticationService;
        private IUseCaseFactory factory;
        
        public string Name => "Buy";
        public string Description => "You will buy something.";
        public bool CanExecute => productRepository.GetProducts().Any() && !authenticationService.IsUserAuthenticated;

        public BuyCommand(IUseCaseFactory factory, IProductRepository productRepository, IAuthenticationService authenticationService)
        {
            this.factory = factory;
            this.productRepository = productRepository;
            this.authenticationService = authenticationService;
        }
        public void Execute()
        {
            var useCase = factory.Create<BuyUseCase>();
            useCase.Execute();
        }
    }
}
