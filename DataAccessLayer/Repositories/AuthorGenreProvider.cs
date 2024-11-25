using DataAccessLayer.Context;
using DataAccessLayer.DTO;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccessLayer.Repositories
{
    public class AuthorGenreProvider : IAuthorGenreProvider
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<AuthorGenreProvider> _logger;

        public AuthorGenreProvider(ApplicationDBContext context, ILogger<AuthorGenreProvider> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<AuthorDetails>> GetAllAuthorsAsync()
        {
            //var authorDetails = _context.Authors;
            try
            {
                //if (authorDetails == null)
                //{
                //    _logger.LogWarning("No authors found.");
                //    throw new ArgumentNullException("Authors aren't available");
                //}
                //var authors = await _context.Authors.Include(author => author.Books).ToListAsync();

                var authors = await _context.Authors
                              .Include(author => author.Books)
                              .Select(author => new AuthorDetails
                              {
                                  Id = author.Id,
                                  AuthorName = author.AuthorName,
                                  Ratings = author.Ratings,
                                  Books = author.Books.Select(book => new BookDetails
                                  {
                                      Id = book.Id,
                                      Title = book.Title,
                                      Description = book.Description
                                  }).ToList()
                              }).ToListAsync();
                return authors;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all authors.");
                throw new InvalidOperationException("Unable to fetch authors. Please try again later.");
            }
        }

        public async Task<Authors?> SaveAuthorAsync(SaveAuthor authorDTO)
        {
            try
            {
                if (authorDTO == null)
                {
                    throw new ArgumentNullException(nameof(authorDTO));
                }
                else
                {
                    var authorDetails = new Authors
                    {
                        Id = authorDTO.Id,
                        AuthorName = authorDTO.AuthorName
                    };

                    await _context.Authors.AddAsync(authorDetails);
                    await _context.SaveChangesAsync();
                    return authorDetails;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving the author: {@Author}", authorDTO);
                throw new InvalidOperationException("Unable to save the response. Please try again later.");
            }
        }
        public async Task<Authors> GetAuthorByIdAsync(int id)
        {
            try
            {
                if (id == null)
                {
                    _logger.LogWarning("No author found with this id.");
                    throw new ArgumentNullException("Author isn't available with this id");
                }
                return await _context.Authors.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the author with ID: {id}", id);
                throw new InvalidOperationException($"Unable to fetch the author with ID: {id}. Please try again later.");
            }
        }
        public async Task<Authors?> UpdateAuthorAsync(SaveAuthor author)
        {
            try
            {
                var existingAuthor = await _context.Authors.FindAsync(author.Id);
                if (existingAuthor == null)
                {
                    return null;
                }
                existingAuthor.Id = author.Id;
                existingAuthor.AuthorName = author.AuthorName;

                await _context.SaveChangesAsync();
                return existingAuthor;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the author");
                throw new InvalidOperationException("Unable to save the response. Please try again later.");
            }
        }
        public async Task<string?> DeleteAuthorAsync(int id)
        {
            try
            {
                var author = await _context.Authors.FindAsync(id);
                if (author != null)
                {
                    _context.Authors.Remove(author);
                    await _context.SaveChangesAsync();
                    return "Author deleted successfully";
                }
                else
                {
                    return "Author wasn't found";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the author with id: {Id}", id);
                throw new InvalidOperationException("Unable to delete the author. Please try again later.");
            }
        }


        //Genre Provider
        public async Task<IEnumerable<GenreDetails>> GetAllGenresAsync()
        {
            //var genres = _context.Genres;
            try
            {
                //if (genres == null)
                //{
                //    _logger.LogWarning("No genres found.");
                //    throw new ArgumentNullException("Genres aren't available");
                //}
                //return await genres.ToListAsync();
                var genres = await _context.Genres
                              .Include(genre => genre.Books)
                              .Select(genre => new GenreDetails
                              {
                                  Id = genre.Id,
                                  Genre = genre.Genre,
                                  Books = genre.Books.Select(book => new BookDetails
                                  {
                                      Id = book.Id,
                                      Title = book.Title,
                                      Description = book.Description
                                  }).ToList()
                              }).ToListAsync();
                return genres;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all genres.");
                throw new InvalidOperationException("Unable to fetch genres. Please try again later.");
            }
        }
        public async Task<Genres?> SaveGenreAsync(SaveGenre genreDTO)
        {
            try
            {
                if (genreDTO == null)
                {
                    throw new ArgumentNullException(nameof(genreDTO));
                }
                else
                {
                    var genreDetails = new Genres
                    {
                        Id = genreDTO.Id,
                        Genre = genreDTO.Genre,
                    };

                    await _context.Genres.AddAsync(genreDetails);
                    await _context.SaveChangesAsync();
                    return genreDetails;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving the genre: {@Genre}", genreDTO);
                throw new InvalidOperationException("Unable to save the response. Please try again later.");
            }
        }
        public async Task<Genres> GetGenreByIdAsync(int id)
        {
            try
            {
                if (id == null)
                {
                    _logger.LogWarning("No genre found with this id.");
                    throw new ArgumentNullException("genre isn't available with this id");
                }
                return await _context.Genres.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the genre with ID: {id}", id);
                throw new InvalidOperationException($"Unable to fetch the genre with ID: {id}. Please try again later.");
            }
        }
        public async Task<Genres?> UpdateGenreAsync(SaveGenre genre)
        {
            try
            {
                var existingGenre = await _context.Genres.FindAsync(genre.Id);
                if (existingGenre == null)
                {
                    return null;
                }
                existingGenre.Id = genre.Id;
                existingGenre.Genre = genre.Genre;

                await _context.SaveChangesAsync();
                return existingGenre;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the genre");
                throw new InvalidOperationException("Unable to save the response. Please try again later.");
            }
        }
        public async Task<string?> DeleteGenreAsync(int id)
        {
            try
            {
                var genre = await _context.Genres.FindAsync(id);
                if (genre != null)
                {
                    _context.Genres.Remove(genre);
                    await _context.SaveChangesAsync();
                    return "Genre deleted successfully";
                }
                else
                {
                    return "Genre wasn't found";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the genre with id: {Id}", id);
                throw new InvalidOperationException("Unable to delete the genre. Please try again later.");
            }
        }
    }
}
