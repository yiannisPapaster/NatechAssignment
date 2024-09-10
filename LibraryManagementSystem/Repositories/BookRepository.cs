using System.Collections.Generic;             
using System.Threading.Tasks;                
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books = new List<Book>();

        public Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return Task.FromResult<IEnumerable<Book>>(_books);
        }

        public Task AddBookAsync(Book book)
        {
            _books.Add(book);
            return Task.CompletedTask;
        }

        public Task UpdateBookAsync(Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.ISBN = book.ISBN;
                existingBook.Genre = book.Genre;
                existingBook.Pages = book.Pages;
            }
            return Task.CompletedTask;
        }

        public Task DeleteBookAsync(Book book)
        {
            _books.Remove(book);
            return Task.CompletedTask;
        }
    }
}
