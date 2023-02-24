namespace iQuest.VendingMachine.PresentationLayer
{
    internal interface ICardPaymentTerminal
    {
        public string AskForCardNumber();
        
        public void TransactionDone();

        public void TransactionFailed();
        
    }
}