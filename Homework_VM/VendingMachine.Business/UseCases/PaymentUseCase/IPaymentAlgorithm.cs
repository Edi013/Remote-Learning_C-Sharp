
namespace iQuest.VendingMachine.UseCases
{
    internal interface IPaymentAlgorithm
    {
        public string Name { get; }

        public void Run(float price);
    }
}
