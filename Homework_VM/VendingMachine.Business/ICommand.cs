namespace iQuest.VendingMachine.Business
{
    public interface ICommand
    {
        public string Name { get; }
        public string Description { get; }

        public bool CanExecute { get; }
        public void Execute();
    }
}
