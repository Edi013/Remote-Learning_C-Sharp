namespace iQuest.BooksAndNews.Application.Publications
{
    public class Newspaper
    {
        public string Title { get; set; }

        public int Number { get; set; }
        public override string ToString()
        {
            return $"Newspaper {Title},  No. {Number}";
        }
    }
}