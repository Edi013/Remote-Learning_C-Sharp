namespace iQuest.VendingMachine.Business.Exceptions
{
    public class InvalidPaymentInputException : Exception
    {
        private const string messageProductNotAvailable = "Invalid input while paying !";

        public InvalidPaymentInputException(string message = messageProductNotAvailable)
            : base(message)
        {
        }
        public InvalidPaymentInputException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
