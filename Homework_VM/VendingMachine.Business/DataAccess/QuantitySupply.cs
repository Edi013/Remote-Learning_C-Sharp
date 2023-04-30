using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Business
{
    public class QuantitySupply
    {
        public int ColumnId { get; set; }
        public int Quantity { get; set; }
        public QuantitySupply()
        {
        }
        public QuantitySupply(int columnId, int quantity)
        {
            ColumnId = columnId;
            Quantity = quantity;
        }
    }
}
