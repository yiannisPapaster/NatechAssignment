using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    // GET: api/books
    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _bookService.GetAllBooksAsync();
        return Ok(books);
    }

    // GET: api/books/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    // POST: api/books
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] BookDto bookDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var addedBook = await _bookService.AddBookAsync(bookDto);
        return CreatedAtAction(nameof(GetBookById), new { id = addedBook.Id }, addedBook);
    }

    // PUT: api/books/{id}
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] BookDto bookDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedBook = await _bookService.UpdateBookAsync(id, bookDto);
        if (updatedBook == null)
        {
            return NotFound();
        }
        return Ok(updatedBook);
    }

    // DELETE: api/books/{id}
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _bookService.DeleteBookAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    // GET: api/books/search
    [HttpGet("search")]
    public async Task<IActionResult> SearchBooks([FromQuery] string searchTerm)
    {
        var books = await _bookService.SearchBooksAsync(searchTerm);
        return Ok(books);
    }

    // GET: api/books/genre/{genre}
    [HttpGet("genre/{genre}")]
    public async Task<IActionResult> GetBooksByGenre(string genre)
    {
        var books = await _bookService.GetBooksByGenreAsync(genre);
        return Ok(books);
    }

    // GET: api/books/author/{author}]
    [HttpGet("author/{author}")]
    public async Task<IActionResult> GetBooksByAuthor(string author)
    {
        var books = await _bookService.GetBooksByAuthorAsync(author);
        return Ok(books);
    }

    // GET: api/books/health
    [HttpGet("health")]
    public IActionResult HealthCheck()
    {
        return Ok("API is running (Health check).");
    }
}
