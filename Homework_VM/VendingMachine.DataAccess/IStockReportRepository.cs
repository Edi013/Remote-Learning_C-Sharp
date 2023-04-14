using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.DataAccess
{
    public interface IStockReportRepository
    {
        public void Add(StockReport stockReport);
    }
}
