using BusinessLayer.Model;
using DataAccessLayer.DTO;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public interface IAuthorGenreService
    {
        Task<IEnumerable<AuthorResponse>> GetAllAuthorsAsync();
        Task<Authors?> SaveAuthorAsync(SaveAuthor author);
        Task<Authors> GetAuthorByIdAsync(int id);
        Task<Authors?> UpdateAuthorAsync(SaveAuthor author);
        Task<string?> DeleteAuthorAsync(int id);


        Task<IEnumerable<GenreResponse>> GetAllGenresAsync();
        Task<Genres?> SaveGenreAsync(SaveGenre genre);
        Task<Genres> GetGenreByIdAsync(int id);
        Task<Genres?> UpdateGenreAsync(SaveGenre genre);
        Task<string?> DeleteGenreAsync(int id);
    }
}
