using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Business
{
    public class TimeInterval
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public TimeInterval(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
