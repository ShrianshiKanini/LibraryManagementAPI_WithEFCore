using BusinessLayer.Services.Interfaces;
using DataAccessLayer.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement_WithEFCore.Controllers
{
    [Route("api/authors-genres")]
    [ApiController]
    public class AuthorGenreController : ControllerBase
    {
        private readonly IAuthorGenreService _authorGenreService;

        public AuthorGenreController(IAuthorGenreService authorGenreService)
        {
            _authorGenreService = authorGenreService;
        }

        [HttpGet("authors")]
        public async Task<IActionResult> GetAllAuthorsAsync()
        {
            var author = await _authorGenreService.GetAllAuthorsAsync();
            return Ok(author);
        }

        [HttpGet("authors/{id}")]
        public async Task<IActionResult> GetAuthorByIdAsync(int id)
        {
            var author = await _authorGenreService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost("authors")]
        public async Task<IActionResult> SaveAuthorAsync([FromBody] SaveAuthor author)
        {
            await _authorGenreService.SaveAuthorAsync(author);
            return Ok(author);
        }

        [HttpPut("authors/{id}")]
        public async Task<IActionResult> UpdateAuthorAsync(int id, [FromBody] SaveAuthor author)
        {
            var authorDetails = await _authorGenreService.UpdateAuthorAsync(author);
            return Ok(authorDetails);
        }

        [HttpDelete("authors/{id}")]
        public async Task<IActionResult> DeleteAuthorAsync(int id)
        {
            var author = await _authorGenreService.DeleteAuthorAsync(id);
            return Ok(author);
        }



        //Genre controller
        [HttpGet("genres")]
        public async Task<IActionResult> GetAllGenresAsync()
        {
            var genre = await _authorGenreService.GetAllGenresAsync();
            return Ok(genre);
        }

        [HttpGet("genres/{id}")]
        public async Task<IActionResult> GetGenreByIdAsync(int id)
        {
            var genre = await _authorGenreService.GetGenreByIdAsync(id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        [HttpPost("genres")]
        public async Task<IActionResult> SaveGenreAsync([FromBody] SaveGenre genre)
        {
            await _authorGenreService.SaveGenreAsync(genre);
            return Ok(genre);
        }

        [HttpPut("genres/{id}")]
        public async Task<IActionResult> UpdateGenreAsync(int id, [FromBody] SaveGenre genre)
        {
            var genreDetails = await _authorGenreService.UpdateGenreAsync(genre);
            return Ok(genreDetails);
        }

        [HttpDelete("genres/{id}")]
        public async Task<IActionResult> DeleteGenreAsync(int id)
        {
            var genre = await _authorGenreService.DeleteGenreAsync(id);
            return Ok(genre);
        }
    }
}
