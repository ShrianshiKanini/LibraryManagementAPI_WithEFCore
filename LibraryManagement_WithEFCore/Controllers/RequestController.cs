using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.DTO;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement_WithEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _reqService;

        public RequestController(IRequestService reqService)
        {
            _reqService = reqService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            var req = await _reqService.GetAllRequestAsync();
            return Ok(req);
        }
        [HttpPost]
        public async Task<IActionResult> SaveRequestAsync([FromBody] SaveRequestdBook request)
        {
            await _reqService.SaveRequestAsync(request);
            return Ok(request);
        }
    }
}
