using iQuest.BooksAndNews.Common;
using System;

namespace iQuest.BooksAndNews.Application
{
    public class PrintNewspapper : EventArgs
    {
        public Newspaper PrintedNewspapper { get; }
        public PrintNewspapper(Newspaper item)
        {
            PrintedNewspapper = item;
        }
    }
}
