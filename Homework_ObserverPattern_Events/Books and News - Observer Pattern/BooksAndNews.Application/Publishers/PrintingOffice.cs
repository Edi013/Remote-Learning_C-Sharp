using iQuest.BooksAndNews.Application.DataAccess;
using iQuest.BooksAndNews.Application.Publications;
using iQuest.BooksAndNews.Application.Subscribers;
using System;
using System.Collections.Generic;

namespace iQuest.BooksAndNews.Application.Publishers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is the class that will publish books and newspapers.
    /// It must offer a mechanism through which different other classes can subscribe ether
    /// to books or to newspaper.
    /// When a book or newspaper is published, the PrintingOffice must notify all the corresponding
    /// subscribers.
    /// </summary>
    public class PrintingOffice
    {
        private IBookRepository _bookRepository;
        private INewspaperRepository _newspaperRepository;
        private ILog _logger;

        public event EventHandler<PrintBook> BookPrinted;
        public event EventHandler<PrintNewspapper> NewspaperPrinted;

        public PrintingOffice(IBookRepository bookRepository, INewspaperRepository newspaperRepository, ILog log)
        {
            _bookRepository = bookRepository;
            _newspaperRepository = newspaperRepository;
            _logger = log;
        }

        public void PrintRandom(int bookCount, int newspaperCount) //
        {
            for(int i = 0; i < bookCount; i++)
            {
                var book = _bookRepository.GetRandom();
                string aux = book.ToString();

                Console.WriteLine("-------NEW BOOK------------");
                Console.WriteLine("Book printed" + aux);

                HandlerPrintedBook(new PrintBook(book));
            }
            for(int i = 0; i < newspaperCount; i++)
            {
                var newspapper = _newspaperRepository.GetRandom();
                string aux = newspapper.ToString();
                
                Console.WriteLine("-------NEW NEWSPAPER------------");
                Console.WriteLine("Newspaper printed" + aux);
                
                HandlerPrintedNewspapper(new PrintNewspapper(newspapper));
            }
        }
        public void HandlerPrintedBook(PrintBook e)
        {
            EventHandler<PrintBook> raiseEvent = BookPrinted;

            if(raiseEvent != null)
            {
                raiseEvent(this, e);
            }
        }
        public void HandlerPrintedNewspapper(PrintNewspapper e)
        {
            EventHandler<PrintNewspapper> raiseEvent = NewspaperPrinted;

            if (raiseEvent != null)
            {
                raiseEvent(this, e);
            }
        }
    }
}