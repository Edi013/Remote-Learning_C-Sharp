namespace iQuest.VendingMachine.Business
{
    public interface IMainDisplay
    {
        public IUseCase ChooseCommand(IEnumerable<IUseCase> useCases);
        public string AskForPassword();

        public void DisplayLine(string message);
    }
}
