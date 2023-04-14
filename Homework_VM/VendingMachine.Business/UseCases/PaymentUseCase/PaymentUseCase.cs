using iQuest.VendingMachine.Business.Exceptions;

namespace iQuest.VendingMachine.Business
{
    public class PaymentUseCase : IPaymentUseCase
    {
        private readonly IBuyView buyView;
        private readonly IEnumerable<IPaymentAlgorithm> paymentAlgorithms;
        private readonly List<PaymentMethod> paymentMethods;

        public PaymentUseCase(IBuyView buyView, IEnumerable<IPaymentAlgorithm> paymentAlgorithms) 
        {
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.paymentAlgorithms = paymentAlgorithms ?? throw new ArgumentNullException(nameof(paymentAlgorithms)); 
            this.paymentMethods =
                new List<PaymentMethod>()
                {
                    new PaymentMethod(1, "Card"),
                    new PaymentMethod(2, "Cash")
                } ?? throw new ArgumentNullException(nameof(paymentMethods));
        }
        public string Name => "pay";
        public string Description => "Payment method";
        public void Execute(float price)
        {
            int paymentMethodIndex = buyView.AskForPaymentMethod(paymentMethods);
            if (paymentMethodIndex != 1 && paymentMethodIndex != 2)
                throw new InvalidPaymentMethodException();

            paymentAlgorithms.ElementAt(paymentMethodIndex - 1).Run(price);
        }
    }
}
