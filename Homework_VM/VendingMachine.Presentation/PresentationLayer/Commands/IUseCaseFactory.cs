using Autofac;

namespace iQuest.VendingMachine.Presentation
{
    public interface IUseCaseFactory
    {
        public T Create<T>();
    }
}
