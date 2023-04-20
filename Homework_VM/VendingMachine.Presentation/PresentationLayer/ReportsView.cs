using System.Runtime.InteropServices;
using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.Presentation
{
    public class ReportsView : IReportsView
    {
        private DateTime RequestDateTimeForReport(string displayedRequest)
        {
            DateTime result;
            while (true)
            {
                Console.WriteLine("Input report "+ displayedRequest + " date in the format \"YYYY-MM-DD\":");
                if (DateTime.TryParse(Console.ReadLine(), out result))
                    return result;
                Console.WriteLine("Invalid / wrong date format.");
            }
        }
        private DateTime RequestReportStartDate()
        {
            return RequestDateTimeForReport("start");
        }
        private DateTime RequestReportEndDate()
        {
            return RequestDateTimeForReport("end");
        }

        public TimeInterval AskForTimeInterval()
        {
            return new TimeInterval
                (RequestReportStartDate(), RequestReportEndDate());
        }
        public void DisplaySuccessMessage([Optional] string displayInformationOnNewLine)
        {
            Console.WriteLine("Operation succeded.\n" + displayInformationOnNewLine);
        }
        
    }
}
