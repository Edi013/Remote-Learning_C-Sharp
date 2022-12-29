using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Interfaces
{
    internal interface ITurnOffWasRequestedChecker
    {
        public bool Status { get; set; }
        public void TurnOff();
    }
}
