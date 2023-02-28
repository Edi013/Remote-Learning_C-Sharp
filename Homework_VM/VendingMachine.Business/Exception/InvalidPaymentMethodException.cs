namespace iQuest.VendingMachine.Business.Exceptions
{
    public class InvalidPaymentMethodException : Exception
    {
        private const string messageProductNotAvailable = "Invalid payment method!";

        public InvalidPaymentMethodException(string message = messageProductNotAvailable)
            : base(message)
        {
        }
        public InvalidPaymentMethodException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
