using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManagementSystem.Models; 

namespace LibraryManagementSystem.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(Book book);
    }
}