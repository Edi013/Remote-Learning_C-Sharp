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

        private List<ISubscriber> subscribers;

        public event EventHandler<CustomEvent> BookRelease;
        public event EventHandler<CustomEvent> NewspaperRelease;


        public PrintingOffice(IBookRepository bookRepository, INewspaperRepository newspaperRepository, ILog log)
        {
            _bookRepository = bookRepository;
            _newspaperRepository = newspaperRepository;
            _logger = log;

            subscribers = new List<ISubscriber>();
        }

        public void PrintRandom(int bookCount, int newspaperCount) //
        {
            for(int i = 0; i < bookCount; i++)
            {
                Console.WriteLine("-------NEW BOOK------------");
                string aux = _bookRepository.GetRandom().ToString();
                Console.WriteLine("Book printed" + aux);
                HandlerBookRelease(new CustomEvent(aux));
            }
            for(int i = 0; i < newspaperCount; i++)
            {
                Console.WriteLine("-------NEW NEWSPAPER------------");
                string aux = _newspaperRepository.GetRandom().ToString();
                Console.WriteLine("Newspaper printed" + aux);
                HandlerNewspaperRelease(new CustomEvent(aux));
            }
        }
        public void HandlerBookRelease(CustomEvent e)
        {
            EventHandler<CustomEvent> raiseEvent = BookRelease;

            if(raiseEvent != null)
            {
                raiseEvent(this, e);
            }
        }
        public void HandlerNewspaperRelease(CustomEvent e)
        {
            EventHandler<CustomEvent> raiseEvent = NewspaperRelease;

            if (raiseEvent != null)
            {
                raiseEvent(this, e);
            }
        }


        public void Subscribe(ISubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }
        public void Unsubscribe(ISubscriber subscriber)
        {
            subscribers.Remove(subscriber);
        }
    }
}