using DataAccessLayer.Context;
using DataAccessLayer.DTO;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;
using static System.Reflection.Metadata.BlobBuilder;

namespace DataAccessLayer.Repositories
{
    /// <summary>
    /// This is repository class for bookController
    /// </summary>
    public class BookProvider:IBookProvider
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<BookProvider> _logger;

        public BookProvider(ApplicationDBContext context, ILogger<BookProvider> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// This method will etch all the books from books table
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<IEnumerable<BookDetails>> GetAllBooksAsync()
        {
            var booksDetails = from book in _context.Books
                                        join author in _context.Authors
                                        on book.AuthorId equals author.Id
                                        join genre in _context.Genres
                                        on book.GenreId equals genre.Id
                                        select new BookDetails
                                        {
                                            Id = book.Id,
                                            AuthorId = book.AuthorId,
                                            AuthorName = author.AuthorName,
                                            GenreId = book.GenreId,
                                            Genre= genre.Genre,
                                            Title= book.Title,
                                            Description= book.Description,
                                            BookStatus= book.BookStatus,
                                        };
            return await booksDetails.ToListAsync();

            //var books = _context.Books;
            //try 
            //{
            //    if (books == null)
            //    {
            //        _logger.LogWarning("No books found.");
            //        throw new ArgumentNullException("Books aren't available");
            //    }
            //    return await books.ToListAsync();
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, "An error occurred while retrieving all books.");
            //    throw new InvalidOperationException("Unable to fetch books. Please try again later.");
            //}

        }

        /// <summary>
        /// This method will return book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<Books> GetBookByIdAsync(int id)
        {
            try
            {
                if (id == null)
                {
                    _logger.LogWarning("No books found with this id.");
                    throw new ArgumentNullException("Book isn't available with this id");
                }
                return await _context.Books.FindAsync(id);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,"An error occurred while retrieving the book with ID: {id}",id);
                throw new InvalidOperationException($"Unable to fetch the book with ID: {id}. Please try again later.");
            }
            
        }

        /// <summary>
        /// This method will insert book into books table
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<Books?> SaveBookAsync(SaveBook bookDto)
        {
            try
            {
                if (bookDto == null)
                {
                    throw new ArgumentNullException(nameof(bookDto));
                }
                else
                {
                    var bookDetails = new Books
                    {
                        AuthorId = bookDto.AuthorId,
                        GenreId = bookDto.GenreId,
                        Title = bookDto.Title,
                        Description = bookDto.Description,
                        BookStatus = bookDto.BookStatus
                    };

                    await _context.Books.AddAsync(bookDetails);
                    await _context.SaveChangesAsync();
                    return bookDetails;
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving the book: {@Book}", bookDto);
                throw new InvalidOperationException("Unable to save the response. Please try again later.");
            }
            
        }

        /// <summary>
        /// This method will update the book of the given ID
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<Books?> UpdateBookAsync(SaveBook book)
        {
            try
            {
                var existingBook = await _context.Books.FindAsync(book.Id);
                if (existingBook == null)
                {
                    return null;
                }
                existingBook.AuthorId = book.AuthorId;
                existingBook.GenreId = book.GenreId;
                existingBook.Title = book.Title;
                existingBook.Description = book.Description;
                existingBook.BookStatus = book.BookStatus;

                await _context.SaveChangesAsync();
                return existingBook;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the book");
                throw new InvalidOperationException("Unable to save the response. Please try again later.");
            }
            
        }

        /// <summary>
        /// This method will delete the book of given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<string?> DeleteBookAsync(int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);
                if (book != null)
                {
                    _context.Books.Remove(book);
                    await _context.SaveChangesAsync();
                    return "Book deleted successfully";
                }
                else
                {
                    return "Book wasn't found";
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the book with id: {Id}", id);
                throw new InvalidOperationException("Unable to delete the book. Please try again later.");
            }
            
        }
    }
}
