namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public int Pages { get; set; }

        public Book() {}

        public Book(string title, string author, string isbn, string genre, int pages)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Genre = genre;
            Pages = pages;
        }
    }
}