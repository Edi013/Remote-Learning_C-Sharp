using System;
using System.Configuration;
using iQuest.BooksAndNews.DataAccess;

namespace iQuest.BooksAndNews
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Bootstrapping - Application Setup

            Log log = new Log();
            BookRepository bookRepository = new BookRepository();
            NewspaperRepository newspaperRepository = new NewspaperRepository();

            // Run
            string implementation = ConfigurationManager.AppSettings["Implementation"] ?? "Not Found";
            switch (implementation){
                case "Events":
                    Application.PrintingUseCase printingUseCaseEvents = new Application.PrintingUseCase(bookRepository, newspaperRepository, log);
                    printingUseCaseEvents.Execute();
                    break;

                case "Delegates":
                    ApplicationDelegates.PrintingUseCase printingUseCaseDelegates = new ApplicationDelegates.PrintingUseCase(bookRepository, newspaperRepository, log);
                    printingUseCaseDelegates.Execute();
                    break;

                case "Not Found":
                    Console.WriteLine("ConfigurationManager.AppSettings was null");
                    break;

                default:
                    Console.WriteLine("Switch-case reached default case!");
                    break;
            }

            // End

            Pause();
        }

        private static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
            Console.WriteLine();
        }
    }
}