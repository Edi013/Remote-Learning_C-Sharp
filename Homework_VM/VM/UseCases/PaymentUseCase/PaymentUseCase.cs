using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Services;

namespace iQuest.VendingMachine.UseCases
{
    internal class PaymentUseCase : IPaymentUseCase
    {
        private readonly IBuyView buyView;
        private readonly IAuthenticationService authenticationSerivce;
        private          IPaymentAlgorithm paymentMethod;

        private readonly List<PaymentMethod> paymentMethods;

        public PaymentUseCase(IBuyView buyView, IAuthenticationService authenticationSerivce) 
        {
            this.authenticationSerivce = authenticationSerivce;
            this.buyView = buyView;
            paymentMethods =
                new List<PaymentMethod>()
                {
                    new PaymentMethod(1, "Card"),
                    new PaymentMethod(2, "Cash")
                };
        }
        public string Name => "pay";
        public string Description => "Payment method";
        public bool CanExecute => !authenticationSerivce.IsUserAuthenticated;
        public void Execute(float price)
        {
            int paymentMethodIndex = buyView.AskForPaymentMethod(paymentMethods);
            
            paymentMethod = 
                paymentMethodIndex == 1 
                ? new CardPayment() 
                : new CashPayment();

            paymentMethod.Run(price);
        }
    }
}
