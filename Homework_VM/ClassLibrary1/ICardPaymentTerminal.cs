namespace iQuest.VendingMachine.PresentationLayer
{
    public interface ICardPaymentTerminal
    {
        public string AskForCardNumber();
        
        public void TransactionDone();

        public void TransactionFailed();
        
    }
}
