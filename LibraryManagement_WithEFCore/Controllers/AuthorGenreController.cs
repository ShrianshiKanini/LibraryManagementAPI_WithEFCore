using BusinessLayer.Services.Interfaces;
using DataAccessLayer.DTO;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement_WithEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorGenreController : ControllerBase
    {
        private readonly IAuthorGenreService _authorGenreService;

        public AuthorGenreController(IAuthorGenreService authorGenreService)
        {
            _authorGenreService = authorGenreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthorsAsync()
        {
            var author = await _authorGenreService.GetAllAuthorsAsync();
            return Ok(author);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorByIdAsync(int id)
        {
            var author = await _authorGenreService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAuthorAsync([FromBody] SaveAuthor author)
        {
            await _authorGenreService.SaveAuthorAsync(author);
            return Ok(author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthorAsync(int id, [FromBody] SaveAuthor author)
        {
            var authorDetails = await _authorGenreService.UpdateAuthorAsync(author);
            return Ok(authorDetails);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorAsync(int id)
        {
            var author = await _authorGenreService.DeleteAuthorAsync(id);
            return Ok(author);
        }
    }
}
