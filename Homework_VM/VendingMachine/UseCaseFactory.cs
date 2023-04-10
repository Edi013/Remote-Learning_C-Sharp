using Autofac;
using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.Business.Exceptions;
using iQuest.VendingMachine.Presentation;

namespace iQuest.VendingMachine
{
    public class UseCaseFactory : IUseCaseFactory
    {
        private ILifetimeScope container;
        public UseCaseFactory(ILifetimeScope container)
        {
            this.container = container;
        }
        public IUseCase Create<T>() where T : IUseCase
        {
            return container.Resolve<T>();
        }
    }
}
