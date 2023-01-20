using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Exceptions
{
    internal class InvalidInputWhilePayingException : Exception
    {
        private const string messageProductNotAvailable = "Invalid input while paying !";

        public InvalidInputWhilePayingException(string message = messageProductNotAvailable)
            : base(message)
        {
        }
        public InvalidInputWhilePayingException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
