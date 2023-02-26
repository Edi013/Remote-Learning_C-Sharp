namespace iQuest.VendingMachine.Business.Exceptions
{
    public class InvalidColumnNumberException : Exception
    {
        private const string messageInvalidColumnNumber = "Such column number do not exists!";

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
