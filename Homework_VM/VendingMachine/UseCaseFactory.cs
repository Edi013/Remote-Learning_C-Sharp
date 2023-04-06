using Autofac;
using iQuest.VendingMachine.Presentation;

namespace iQuest.VendingMachine
{
    public class UseCaseFactory : IUseCaseFactory
    {
        private IContainer container = AutofacContainer.GetInstance();
        public T Create<T>()
        {
            return container.Resolve<T>();
        }
    }
}
