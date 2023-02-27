using iQuest.BooksAndNews.Application.Publications;
using System;

namespace iQuest.BooksAndNews.Application
{
    public class PrintBook : EventArgs
    {
        public Book PrintedBook { get; }
        public PrintBook(Book item)
        {
            PrintedBook = item;
        }
    }
}
