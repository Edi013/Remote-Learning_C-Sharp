namespace iQuest.VendingMachine.Business
{
    public interface ICardPaymentTerminal
    {
        public string AskForCardNumber();
        
        public void TransactionDone();

        public void TransactionFailed();
        
    }
}
