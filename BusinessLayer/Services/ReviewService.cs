using AutoMapper;
using BusinessLayer.Model;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.DTO;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLayer.Services
{
    public class ReviewService:IReviewService
    {
        public readonly IReviewProvider _repo;
        private readonly IMapper _mapper;

        public ReviewService(IReviewProvider repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<List<ReviewResponse>> GetAllReviewsAsync()
        {
            var reviewDetails = await _repo.GetAllReviewsAsync();
            var reviewData = _mapper.Map<List<ReviewResponse>>(reviewDetails);
            return reviewData;
        }
        public async Task<Review?> SaveReviewAsync(SaveReview review)
        {
            var reviewDetails = _repo.SaveReviewAsync(review);
            return await reviewDetails;
        }
        public async Task<Review> GetReviewByIdAsync(int id)
        {
            var reviewDetails = _repo.GetReviewByIdAsync(id);
            return await reviewDetails;
        }
        public async Task<Review?> UpdateReviewAsync(SaveReview review)
        {
            var reviewDetails = _repo.UpdateReviewAsync(review);
            return await reviewDetails;
        }
        public async Task<string?> DeleteReviewAsync(int id)
        {
            var reviewDetails = _repo.DeleteReviewAsync(id);
            return await reviewDetails;
        }
    }
}
