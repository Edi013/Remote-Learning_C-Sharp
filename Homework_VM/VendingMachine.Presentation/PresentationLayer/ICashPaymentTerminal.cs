using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.PresentationLayer
{
    public interface ICashPaymentTerminal
    {
        public float AskForMoney(float price);
        public void GiveBackChange(float change);
        public void ReleaseMoney(float amount);
    }
}
