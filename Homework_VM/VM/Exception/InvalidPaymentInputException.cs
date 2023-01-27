using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Exceptions
{
    internal class InvalidPaymentInputException : Exception
    {
        private const string messageProductNotAvailable = "Invalid input while paying !";

        public InvalidPaymentInputException(string message = messageProductNotAvailable)
            : base(message)
        {
        }
        public InvalidPaymentInputException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
