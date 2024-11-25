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
    public interface IReviewService
    {
        Task<List<ReviewResponse>> GetAllReviewsAsync();
        Task<Review?> SaveReviewAsync(SaveReview review);
        Task<Review> GetReviewByIdAsync(int id);
        Task<Review?> UpdateReviewAsync(SaveReview review);
        Task<string?> DeleteReviewAsync(int id);
    }
}
