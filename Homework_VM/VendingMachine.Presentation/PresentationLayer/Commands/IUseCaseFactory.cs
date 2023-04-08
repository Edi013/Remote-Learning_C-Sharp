using Autofac;
using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.Presentation
{
    public interface IUseCaseFactory
    {
        public IUseCase Create<T>();
    }
}
