using AutoMapper;
using BusinessLayer.Model;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.DTO;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLayer.Services
{
    public class AuthorGenreService:IAuthorGenreService
    {
        public readonly IAuthorGenreProvider _repo;
        private readonly IMapper _mapper;
        public AuthorGenreService(IAuthorGenreProvider repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<AuthorResponse>> GetAllAuthorsAsync()
        {
            var authorDetails = await _repo.GetAllAuthorsAsync();
            var authorData = _mapper.Map<List<AuthorResponse>>(authorDetails);
            return authorData;
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


        //Genre Services
        public async Task<IEnumerable<GenreResponse>> GetAllGenresAsync()
        {
            var genreDetails = await _repo.GetAllGenresAsync();
            var genreData = _mapper.Map<List<GenreResponse>>(genreDetails);
            return genreData;
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
