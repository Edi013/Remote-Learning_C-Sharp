namespace iQuest.VendingMachine.Business.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        private const string messageProductNotAvailable = "Invalid password!";

        public InvalidPasswordException(string message = messageProductNotAvailable) 
            : base(message) 
        {
        }
        public InvalidPasswordException(string message, Exception innerException)
            : base (message, innerException)
        {
        }
    }
}
