using BusinessLayer.Services.Interfaces;
using DataAccessLayer.DTO;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement_WithEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _booksService;

        public BookController(IBookService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            var books = await _booksService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookByIdAsync(int id)
        {
            var book = await _booksService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBookAsync([FromBody] SaveBook book)
        {
            await _booksService.SaveBookAsync(book);
            //return CreatedAtAction(nameof(GetBookByIdAsync), new { id = book.Id }, book);
            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] SaveBook book)
        {
            var bookDetails = await _booksService.UpdateBookAsync(book);
            return Ok(bookDetails);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _booksService.DeleteBookAsync(id);
            return Ok(book);
        }
    }
}
