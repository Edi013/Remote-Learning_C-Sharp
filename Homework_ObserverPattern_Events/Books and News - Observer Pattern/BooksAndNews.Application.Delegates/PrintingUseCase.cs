using iQuest.BooksAndNews.ApplicationDelegates.Publishers;
using iQuest.BooksAndNews.ApplicationDelegates.Subscribers;
using iQuest.BooksAndNews.Common;
using System;
using System.Collections.Generic;

namespace iQuest.BooksAndNews.ApplicationDelegates
{
    public class PrintingUseCase
    {
        private readonly IBookRepository bookRepository;
        private readonly INewspaperRepository newspaperRepository;
        private readonly ILog log;

        private PrintingOffice printingOffice;
        private readonly List<BookLover> bookLovers = new List<BookLover>();
        private readonly List<NewsHunter> newsHunters = new List<NewsHunter>();

        public PrintingUseCase(IBookRepository bookRepository, INewspaperRepository newspaperRepository, ILog log)
        {
            this.bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            this.newspaperRepository = newspaperRepository ?? throw new ArgumentNullException(nameof(newspaperRepository));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public void Execute()
        {
            CreatePrintingOffice();
            CreateBookLovers();
            CreateNewsHunters();

            printingOffice.PrintRandom(3, 2); //bookLovers, newsHunters
        }

        private void CreatePrintingOffice()
        {
            printingOffice = new PrintingOffice(bookRepository, newspaperRepository, log);
        }

        private void CreateBookLovers()
        {
            BookLover william = new BookLover("William", printingOffice, log, bookLovers);

            BookLover james = new BookLover("James", printingOffice, log, bookLovers);

            BookLover anna = new BookLover("Anna", printingOffice, log, bookLovers);
        }

        private void CreateNewsHunters()
        {
            NewsHunter alice = new NewsHunter("Alice", printingOffice, log, newsHunters);

            NewsHunter johnny = new NewsHunter("Johnny", printingOffice, log, newsHunters);
        }
    }
}