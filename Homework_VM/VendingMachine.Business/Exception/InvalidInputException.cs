namespace iQuest.VendingMachine.Business.Exceptions
{
    public class InvalidInputException : Exception
    {
        private const string messageInvalidInput = "Invalid input!";

        public InvalidInputException(string message = messageInvalidInput) 
            : base(message) 
        {
        }
        public InvalidInputException(string message, Exception innerException)
            : base (message, innerException)
        {
        }
    }
}
