namespace iQuest.BooksAndNews.Common
{
    public class Book
    {
        public string Author { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public override string ToString()
        {
            return $"Book {Title} - {Author} from {Year}";
        }
    }
}
