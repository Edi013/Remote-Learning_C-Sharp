using iQuest.BooksAndNews.Application.Publishers;
using System;

namespace iQuest.BooksAndNews.Application.Subscribers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is a subscriber that is interested to receive notification whenever a book
    /// is printed.
    ///
    /// Subscribe to the printing office and log each book that was printed.
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
            Console.WriteLine($"{_name} received this message: {e.Message}");
        }

        private void Subscribe()
        {
            _printingOffice.Subscribe(this);
            _printingOffice.BookRelease += HandleCustomEvent;
        }

        private void Unsubscribe()
        {
            _printingOffice.Unsubscribe(this);
            _printingOffice.BookRelease -= HandleCustomEvent;
        }
    }
}
