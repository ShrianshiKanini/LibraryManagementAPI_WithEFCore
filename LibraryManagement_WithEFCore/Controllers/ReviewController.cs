using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement_WithEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _service;

        public ReviewController(IReviewService service)
        {
           _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviewsAsync()
        {
            var reviews = await _service.GetAllReviewsAsync();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewByIdAsync(int id)
        {
            var review = await _service.GetReviewByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        [HttpPost]
        public async Task<IActionResult> SaveReviewAsync([FromBody] SaveReview review)
        {
            await _service.SaveReviewAsync(review);
            return Ok(review);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReviewAsync(int id, [FromBody] SaveReview review)
        {
            var reviewDetails = await _service.UpdateReviewAsync(review);
            return Ok(reviewDetails);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReviewAsync(int id)
        {
            var review = await _service.DeleteReviewAsync(id);
            return Ok(review);
        }
    }
}
