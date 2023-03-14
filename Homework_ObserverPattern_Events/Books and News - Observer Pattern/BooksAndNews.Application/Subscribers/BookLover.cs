using iQuest.BooksAndNews.Application.Publishers;
using iQuest.BooksAndNews.Common;
using System;
using System.Collections.Generic;

namespace iQuest.BooksAndNews.Application.Subscribers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is a subscriber that is interested to receive notification whenever a book
    /// is printed.
    ///
    /// AddSubscriber to the printing office and log each book that was printed.
    /// </summary>
    public class BookLover
    {
        private string _name;
        private PrintingOffice _printingOffice;
        private ILog _log;

        public BookLover(string name, PrintingOffice printingOffice,
            ILog log, List<BookLover> bookLovers)
        {
            _name = name;
            _printingOffice = printingOffice;
            _log = log;

            Subscribe(bookLovers);
        }
        void HandleCustomEvent(object sender, PrintBook e)
        {
            _log.WriteInfo($"{_name} received this book: {e.PrintedBook.Title}");
        }

        private void Subscribe(List<BookLover> bookLovers)
        {
            _printingOffice.BookPrinted += HandleCustomEvent;
            bookLovers.Add(this);

        }

        private void Unsubscribe()
        {
            _printingOffice.BookPrinted -= HandleCustomEvent;
        }
    }
}
