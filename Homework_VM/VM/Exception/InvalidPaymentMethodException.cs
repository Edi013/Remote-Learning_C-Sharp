using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Exceptions
{
    internal class InvalidPaymentMethodException : Exception
    {
        private const string messageProductNotAvailable = "Invalid payment method!";

        public InvalidPaymentMethodException(string message = messageProductNotAvailable)
            : base(message)
        {
        }
        public InvalidPaymentMethodException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
