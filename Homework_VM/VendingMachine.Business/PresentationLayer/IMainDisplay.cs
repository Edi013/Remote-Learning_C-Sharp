namespace iQuest.VendingMachine.Business
{
    public interface IMainDisplay
    {
        public ICommand ChooseCommand(IEnumerable<ICommand> useCases);
        public string AskForPassword();
        public void DisplayLine(string message);
    }
}
