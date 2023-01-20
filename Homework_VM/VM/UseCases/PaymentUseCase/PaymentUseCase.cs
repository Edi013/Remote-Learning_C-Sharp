using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Exceptions;

namespace iQuest.VendingMachine.UseCases
{
    internal class PaymentUseCase : IPaymentUseCase
    {
        private readonly IBuyView buyView;
        private readonly List<IPaymentAlgorithm> paymentAlgorithms;
        private readonly List<PaymentMethod> paymentMethods;

        public PaymentUseCase(IBuyView buyView, List<IPaymentAlgorithm> paymentAlgorithms) 
        {
            this.buyView = buyView;
            this.paymentAlgorithms = paymentAlgorithms; 
            this.paymentMethods =
                new List<PaymentMethod>()
                {
                    new PaymentMethod(1, "Card"),
                    new PaymentMethod(2, "Cash")
                };
        }
        public string Name => "pay";
        public string Description => "Payment method";
        public void Execute(float price)
        {
            int paymentMethodIndex = buyView.AskForPaymentMethod(paymentMethods);
            if (paymentMethodIndex != 1 && paymentMethodIndex != 2)
                throw new InvalidPaymentMethodException();

            paymentAlgorithms[paymentMethodIndex-1].Run(price);
        }
    }
}
