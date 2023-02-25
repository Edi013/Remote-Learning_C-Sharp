using iQuest.BooksAndNews.Application.Publishers;
using System;

namespace iQuest.BooksAndNews.Application.Subscribers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is a subscriber that is interested to receive notification whenever news
    /// are printed.
    ///
    /// AddSubscriber to the printing office and log each news that was printed.
    /// </summary>
    public class NewsHunter : ISubscriber
    {
        private string _name;
        private PrintingOffice _printingOffice;
        private ILog _log;

        public NewsHunter(string name, PrintingOffice printingOffice, ILog log)
        {
            _name = name;
            _printingOffice = printingOffice;
            _log = log;

            Subscribe();
        }

        private void Subscribe()
        {
            _printingOffice.AddSubscriber(this);
            _printingOffice.NewspaperPrinted += HandleCustomEvent;
        }

        private void Unsubscribe()
        {
            _printingOffice.RemoveSubscriber(this);
            _printingOffice.NewspaperPrinted -= HandleCustomEvent;
        }
    }
}