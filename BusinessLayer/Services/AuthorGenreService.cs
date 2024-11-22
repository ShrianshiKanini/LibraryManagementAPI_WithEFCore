using BusinessLayer.Services.Interfaces;
using DataAccessLayer.DTO;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLayer.Services
{
    public class AuthorGenreService:IAuthorGenreService
    {
        public readonly IAuthorGenreProvider _repo;
        public AuthorGenreService(IAuthorGenreProvider repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<Authors>> GetAllAuthorsAsync()
        {
            var authorDetails = _repo.GetAllAuthorsAsync();
            return await authorDetails;
        }
        public async Task<Authors?> SaveAuthorAsync(SaveAuthor author)
        {
            var authorDetails = _repo.SaveAuthorAsync(author);
            return await authorDetails;
        }
        public async Task<Authors> GetAuthorByIdAsync(int id)
        {
            var authorDetails = _repo.GetAuthorByIdAsync(id);
            return await authorDetails;
        }
        public async Task<Authors?> UpdateAuthorAsync(SaveAuthor author)
        {
            var authorDetails = _repo.UpdateAuthorAsync(author);
            return await authorDetails;
        }
        public async Task<string?> DeleteAuthorAsync(int id)
        {
            var authorDetails = _repo.DeleteAuthorAsync(id);
            return await authorDetails;
        }


        public async Task<IEnumerable<Genres>> GetAllGenresAsync()
        {
            var genreDetails = _repo.GetAllGenresAsync();
            return await genreDetails;
        }
        public async Task<Genres?> SaveGenreAsync(SaveGenre genre)
        {
            var genreDetails = _repo.SaveGenreAsync(genre);
            return await genreDetails;
        }
        public async Task<Genres> GetGenreByIdAsync(int id)
        {
            var genreDetails = _repo.GetGenreByIdAsync(id);
            return await genreDetails;
        }
        public async Task<Genres?> UpdateGenreAsync(SaveGenre genre)
        {
            var genreDetails = _repo.UpdateGenreAsync(genre);
            return await genreDetails;
        }
        public async Task<string?> DeleteGenreAsync(int id)
        {
            var genreDetails = _repo.DeleteGenreAsync(id);
            return await genreDetails;
        }
    }
}
