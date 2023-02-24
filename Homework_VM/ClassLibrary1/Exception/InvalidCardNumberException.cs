using System.Runtime.Serialization;

namespace iQuest.VendingMachine.Business.Exceptions
{
    public class InvalidCardNumberException : Exception
    {
        private const string message = "Invalid card number !";
        public InvalidCardNumberException(string messageToDisplay = message) : base(messageToDisplay)
        {
        }
    }
}
