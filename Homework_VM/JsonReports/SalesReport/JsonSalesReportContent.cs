using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.JsonReports
{
    public class JsonSalesReportContent : List<SalesReportProduct>
    {
        public JsonSalesReportContent() : base()
        {
        }
    }
}
