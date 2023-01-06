using System.Runtime.Serialization;

namespace iQuest.VendingMachine.PresentationLayer
{
    [Serializable]
    internal class InvalidCardNumberException : Exception
    {
        public InvalidCardNumberException() : base()
        {
        }
    }
}