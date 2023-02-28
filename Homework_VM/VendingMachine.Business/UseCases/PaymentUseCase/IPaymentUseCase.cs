namespace iQuest.VendingMachine.Business
{
    public interface IPaymentUseCase
    {
        public string Name { get; }

        public string Description { get; }

        public void Execute(float price);
    }
}

