namespace iQuest.VendingMachine.Exceptions
{
    public class CancelException : Exception
    {
        private const string messageCancelCommand = "Cancelling command .";

        public CancelException(string message = messageCancelCommand) 
            : base(message) 
        {
        }
        public CancelException(string message, Exception innerException)
            : base (message, innerException)
        {
        }
    }
}