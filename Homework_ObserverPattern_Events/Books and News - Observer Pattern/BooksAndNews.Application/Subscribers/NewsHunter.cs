using iQuest.BooksAndNews.Application.Publishers;
using iQuest.BooksAndNews.Common;
using System;
using System.Collections.Generic;

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
        private ILog _log;

        public NewsHunter(string name, PrintingOffice printingOffice,
            ILog log, List<NewsHunter> bookLovers)
        {
            _name = name;
            _printingOffice = printingOffice;
            _log = log;

            Subscribe(bookLovers);
        }
        void HandleCustomEvent(object sender, PrintNewspapper e)
        {
            _log.WriteInfo($"{_name} received this newspapper: {e.PrintedNewspapper.Title}");
        }

        private void Subscribe(List<NewsHunter> newsHunters)
        {
            _printingOffice.NewspaperPrinted += HandleCustomEvent;
            newsHunters.Add(this);
        }

        private void Unsubscribe()
        {
            _printingOffice.NewspaperPrinted -= HandleCustomEvent;
        }
    }
}