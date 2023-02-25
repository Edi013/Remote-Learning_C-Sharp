using iQuest.BooksAndNews.Application.Publishers;
using System;

namespace iQuest.BooksAndNews.Application.Subscribers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is a subscriber that is interested to receive notification whenever a book
    /// is printed.
    ///
    /// AddSubscriber to the printing office and log each book that was printed.
    /// </summary>
    public class BookLover : ISubscriber
    {
        private string _name;
        private PrintingOffice _printingOffice;
        private ILog _log;

        public BookLover(string name, PrintingOffice printingOffice, ILog log)
        {
            _name = name;
            _printingOffice = printingOffice;
            _log = log;

            Subscribe();
        }
        void HandleCustomEvent(object sender, CustomEvent e)
        {
            _log.WriteInfo($"{_name} received this message: {e.Message}");
        }

        private void Subscribe()
        {
            _printingOffice.AddSubscriber(this);
            _printingOffice.BookPrinted += HandleCustomEvent;
        }

        private void Unsubscribe()
        {
            _printingOffice.RemoveSubscriber(this);
            _printingOffice.BookPrinted -= HandleCustomEvent;
        }
    }
}
