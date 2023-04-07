using Autofac;
using iQuest.VendingMachine.Presentation;

namespace iQuest.VendingMachine
{
    public class UseCaseFactory : IUseCaseFactory
    {
        private ILifetimeScope container;
        public UseCaseFactory(ILifetimeScope container)
        {
            this.container = container.BeginLifetimeScope();
        }
        public T Create<T>()
        {
            return container.Resolve<T>();
        }
    }
}
