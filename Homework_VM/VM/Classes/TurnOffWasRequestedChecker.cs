using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iQuest.VendingMachine.Interfaces;

namespace iQuest.VendingMachine.Classes
{
    internal class TurnOffWasRequestedChecker : ITurnOffWasRequestedChecker
    {
        public bool Status { get; set; }

        public TurnOffWasRequestedChecker()
        {
            Status = false;
        }

        public void TurnOff()
        {
            Status = true;
        }
    }
}
