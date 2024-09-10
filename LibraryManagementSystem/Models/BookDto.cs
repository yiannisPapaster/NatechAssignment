namespace LibraryManagementSystem.Models
{
    public class BookDto
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public string Genre { get; set; }

        public int Pages { get; set; }

        public BookDto(string title, string author, string isbn, string genre, int pages)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Genre = genre;
            Pages = pages;
        }
    }

}
