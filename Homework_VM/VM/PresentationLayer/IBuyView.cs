using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.PresentationLayer
{
    public interface IBuyView
    {
        public int RequestProduct();
        public void DispenseProduct(string productName);
    }
}
