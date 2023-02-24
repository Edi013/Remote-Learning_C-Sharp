namespace iQuest.VendingMachine.Business
{
    public interface ICashPaymentTerminal
    {
        public float AskForMoney(float price);
        public void GiveBackChange(float change);
        public void ReleaseMoney(float amount);
    }
}
