namespace iQuest.VendingMachine.Business
{
    public interface IBuyView
    {
        public int RequestProduct();
        public void DispenseProduct(string productName);
        public int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods);
    }
}
