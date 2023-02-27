using iQuest.BooksAndNews.Application.Publications;
using System;

namespace iQuest.BooksAndNews.Application
{
    public class PrintNewspapper : EventArgs
    {
        public Newspaper PrintedNewspapper { get; set; }
        public PrintNewspapper(Newspaper item)
        {
            PrintedNewspapper = item;
        }
    }
}
