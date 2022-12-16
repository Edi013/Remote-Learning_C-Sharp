namespace iQuest.VendingMachine.Exceptions
{
    public class InvalidColumnNumberException : Exception
    {
        private const string messageInvalidColumnNumber = "Such column number do not exist!";

        public InvalidColumnNumberException(string message = messageInvalidColumnNumber) 
            : base(message) 
        {
        }
        public InvalidColumnNumberException(string message, Exception innerException)
            : base (message, innerException)
        {
        }
    }
}