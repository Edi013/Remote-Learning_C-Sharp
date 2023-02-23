namespace iQuest.VendingMachine.UseCases
{
    internal interface IPaymentUseCase
    {
        public string Name { get; }

        public string Description { get; }

        public void Execute(float price);
    }
}

