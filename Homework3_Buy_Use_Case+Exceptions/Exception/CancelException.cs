namespace iQuest.VendingMachine.Exceptions
{
    public class CancelException : Exception
    {
        public CancelException(string message) 
            : base(message) 
        {
        }
        public CancelException(string message, Exception innerException)
            : base (message, innerException)
        {
        }
    }
}