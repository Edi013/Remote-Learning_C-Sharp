using iQuest.BooksAndNews.Application.Publications;
using iQuest.BooksAndNews.Application.Publishers;
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
        private static ILog _log;

        public BookLover(string name, PrintingOffice printingOffice,
            ILog log, List<BookLover> bookLovers)
        {
            _name = name;
            _printingOffice = printingOffice;
            _log = log;

            Subscribe(bookLovers);
        }

        public static void HandlerBookPrinted(Book item)
        {
            _log.WriteInfo($"One BookLover received book {item.Title} !");
        }

        public void Subscribe(List<BookLover> bookLovers)
        {
            bookLovers.Add(this);
        }
    }
}
