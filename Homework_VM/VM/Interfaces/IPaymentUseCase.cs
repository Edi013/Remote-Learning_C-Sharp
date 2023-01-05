namespace iQuest.VendingMachine.Interfaces
{
    internal interface IPaymentUseCase
    {
        public string Name { get; }

        public string Description { get; }

        public bool CanExecute { get; }

        public void Execute(float price);
    }
}

