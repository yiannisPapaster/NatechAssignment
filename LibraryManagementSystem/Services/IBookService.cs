using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> AddBookAsync(BookDto bookDto);
        Task<Book> UpdateBookAsync(int id, BookDto bookDto);
        Task<Book> DeleteBookAsync(int id);
        Task<IEnumerable<Book>> SearchBooksAsync(string searchTerm);
        Task<IEnumerable<Book>> GetBooksByGenreAsync(string genre);
        Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author);
    }
}
