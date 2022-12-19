namespace iQuest.VendingMachine.Exceptions
{
    public class ProductNotAvailableException : Exception
    {
        private const string messageProductNotAvailable = "Selected product is not available!";

        public ProductNotAvailableException(string message = messageProductNotAvailable) 
            : base(message) 
        {
        }
        public ProductNotAvailableException(string message, Exception innerException)
            : base (message, innerException)
        {
        }
    }
}