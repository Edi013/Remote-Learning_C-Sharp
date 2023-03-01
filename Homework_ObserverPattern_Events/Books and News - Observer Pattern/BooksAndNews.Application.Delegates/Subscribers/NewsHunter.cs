using iQuest.BooksAndNews.Application.Publications;
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
    public class NewsHunter
    {
        private string _name;
        private PrintingOffice _printingOffice;
        private static ILog _log;

        public NewsHunter(string name, PrintingOffice printingOffice,
            ILog log, List<NewsHunter> newsHunters)
        {
            _name = name;
            _printingOffice = printingOffice;
            _log = log;

            Subscribe(newsHunters);
        }

        public static void HandlerNewspaperPrinted(Newspaper item)
        {
            _log.WriteInfo($"One received newspaper {item.Title} !");
        }
        public void Subscribe(List<NewsHunter> newsHunters)
        {
            newsHunters.Add(this);
        }
    }
}