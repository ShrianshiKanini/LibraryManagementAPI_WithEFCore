using DataAccessLayer.Context;
using DataAccessLayer.DTO;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccessLayer.Repositories
{
    public class ReviewProvider:IReviewProvider
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<ReviewProvider> _logger;

        public ReviewProvider(ApplicationDBContext context, ILogger<ReviewProvider> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<List<ReviewDetails>> GetAllReviewsAsync()
        {
            var reviewDetails = await _context.Review
                                              .Join(_context.Books,
                                                    review => review.BookId,
                                                    book => book.Id,
                                                   (review, book) => new { review, book })
                                              .Join(_context.Users,
                                                    joined => joined.review.UserId,
                                                    user => user.Id,
                                                   (joined, user) => new ReviewDetails
                                                   {
                                                       Id = joined.review.Id,
                                                       UserId = user.Id,
                                                       BookId = joined.book.Id,
                                                       BookName = joined.book.Title,
                                                       UserName = user.Name,
                                                       ReviewDate = joined.review.ReviewDate,
                                                       ReviewComments = joined.review.ReviewComments,
                                                       Ratings = joined.review.Ratings
                                                   })
                                            .ToListAsync();

            return reviewDetails;
        }
        public async Task<Review?> SaveReviewAsync(SaveReview reviewDTO)
        {
            if (reviewDTO == null)
            {
                throw new ArgumentNullException(nameof(reviewDTO));
            }
            if (reviewDTO.Ratings < 1 || reviewDTO.Ratings > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(reviewDTO.Ratings), "Rating must be between 1 and 10.");
            }
            else
            {
                var review = new Review
                {
                    BookId = reviewDTO.BookId,
                    UserId = reviewDTO.UserId,
                    ReviewDate = reviewDTO.ReviewDate,
                    ReviewComments = reviewDTO.ReviewComments,
                    Ratings = reviewDTO.Ratings
                };

                await _context.Review.AddAsync(review);
                await _context.SaveChangesAsync();
                await UpdateBookRatingAsync(reviewDTO.BookId);
                var book = await _context.Books.FindAsync(reviewDTO.BookId);
                if (book != null)
                {
                    await UpdateAuthorRatingAsync(book.AuthorId);
                    
                }
                return review;
            }
        }
        public async Task<Review> GetReviewByIdAsync(int id)
        {
            try
            {
                if (id == null)
                {
                    _logger.LogWarning("No review found with this id.");
                    throw new ArgumentNullException("Review isn't available with this id");
                }
                return await _context.Review.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the review with ID: {id}", id);
                throw new InvalidOperationException($"Unable to fetch the review with ID: {id}. Please try again later.");
            }
        }
        public async Task<Review?> UpdateReviewAsync(SaveReview review)
        {
            try
            {
                var existingReview = await _context.Review.FindAsync(review.Id);
                if (existingReview == null)
                {
                    return null;
                }
                existingReview.ReviewDate = review.ReviewDate;
                existingReview.BookId = review.BookId;
                existingReview.UserId = review.UserId;
                existingReview.ReviewComments = review.ReviewComments;
                existingReview.Ratings = review.Ratings;

                await _context.SaveChangesAsync();
                return existingReview;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the review");
                throw new InvalidOperationException("Unable to save the response. Please try again later.");
            }
        }
        public async Task<string?> DeleteReviewAsync(int id)
        {
            try
            {
                var review = await _context.Review.FindAsync(id);
                if (review != null)
                {
                    _context.Review.Remove(review);
                    await _context.SaveChangesAsync();
                    return "Review deleted successfully";
                }
                else
                {
                    return "Review wasn't found";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the review with id: {Id}", id);
                throw new InvalidOperationException("Unable to delete the review. Please try again later.");
            }
        }

        public async Task UpdateAuthorRatingAsync(int authorId)
        {
                var books = await _context.Books
                    .Where(b => b.AuthorId == authorId)
                    .Select(b => b.Id)
                    .ToListAsync();

                var ratings = await _context.Review
                    .Where(r => books.Contains(r.BookId))
                    .Select(r => r.Ratings)
                    .ToListAsync();

                var averageRating = ratings.Any() ? ratings.Average() : 0;

                var author = await _context.Authors.FindAsync(authorId);
                if (author != null)
                {
                    author.Ratings = (int)Math.Round(averageRating);
                    await _context.SaveChangesAsync();
                }
            
        }

        public async Task UpdateBookRatingAsync(int bookId)
        {
            var bookReviews = await _context.Review
                .Where(r => r.BookId == bookId)
                .ToListAsync();

            var averageRating = bookReviews.Average(r => r.Ratings);

            var book = await _context.Books.FindAsync(bookId);
            if (book != null)
            {
                book.Ratings = (int)Math.Round(averageRating); 
                _context.Books.Update(book);
                await _context.SaveChangesAsync();
            }

        }

    }
}
