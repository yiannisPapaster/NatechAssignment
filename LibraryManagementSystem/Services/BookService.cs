using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // Method to get all books
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllBooksAsync();
        }

        // Method to get a book by ID
        public async Task<Book> GetBookByIdAsync(int id)
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return books.FirstOrDefault(b => b.Id == id);
        }

        // Method to add a new book
        public async Task<Book> AddBookAsync(BookDto bookDto)
        {
            var newBook = new Book
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                ISBN = bookDto.ISBN,
                Genre = bookDto.Genre,
                Pages = bookDto.Pages
            };

            await _bookRepository.AddBookAsync(newBook);
            return newBook;
        }

        // Method to update an existing book
        public async Task<Book> UpdateBookAsync(int id, BookDto bookDto)
        {
            var books = await _bookRepository.GetAllBooksAsync();
            var bookToUpdate = books.FirstOrDefault(b => b.Id == id);

            if (bookToUpdate != null)
            {
                bookToUpdate.Title = bookDto.Title;
                bookToUpdate.Author = bookDto.Author;
                bookToUpdate.ISBN = bookDto.ISBN;
                bookToUpdate.Genre = bookDto.Genre;
                bookToUpdate.Pages = bookDto.Pages;

                await _bookRepository.UpdateBookAsync(bookToUpdate);
            }

            return bookToUpdate;
        }

        // Method to delete a book by ID
        public async Task<Book> DeleteBookAsync(int id)
        {
            var books = await _bookRepository.GetAllBooksAsync();
            var bookToDelete = books.FirstOrDefault(b => b.Id == id);

            if (bookToDelete != null)
            {
                await _bookRepository.DeleteBookAsync(bookToDelete);
            }

            return bookToDelete;
        }

        // Method to search for books by a search term
        public async Task<IEnumerable<Book>> SearchBooksAsync(string searchTerm)
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return books.Where(b => b.Title.Contains(searchTerm) || b.Author.Contains(searchTerm));
        }

        // Method to get books by genre
        public async Task<IEnumerable<Book>> GetBooksByGenreAsync(string genre)
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return books.Where(b => b.Genre == genre);
        }

        // Method to get books by author
        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author)
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return books.Where(b => b.Author == author);
        }
    }
}
