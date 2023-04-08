namespace iQuest.VendingMachine.Business.Exceptions
{
    public class FactoryTypeException : Exception
    {
        private const string messageCancelCommand = "Cancelling command .";

        public FactoryTypeException(string message = messageCancelCommand) 
            : base(message) 
        {
        }
        public FactoryTypeException(string message, Exception innerException)
            : base (message, innerException)
        {
        }
    }
}
