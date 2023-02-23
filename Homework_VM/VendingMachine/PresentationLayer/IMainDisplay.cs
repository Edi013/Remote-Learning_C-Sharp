using iQuest.VendingMachine.Interfaces;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal interface IMainDisplay
    {
        public IUseCase ChooseCommand(IEnumerable<IUseCase> useCases);
        public string AskForPassword();
    }
}