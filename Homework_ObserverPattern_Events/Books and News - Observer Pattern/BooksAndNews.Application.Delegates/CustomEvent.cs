using System;

namespace iQuest.BooksAndNews.Application
{
    public class CustomEvent : EventArgs
    {
        public CustomEvent(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
