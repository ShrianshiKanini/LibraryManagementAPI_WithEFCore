using AutoMapper;
using BusinessLayer.Model;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.DTO;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class RequestService:IRequestService
    {
        private readonly IRequestProvider _repo;
        private readonly IMapper _mapper;

        public RequestService(IRequestProvider repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<List<RequestedBookResponse>> GetAllRequestAsync()
        {
            var requestedBookDetails = await _repo.GetAllRequestAsync();
            var requestedBookData = _mapper.Map<List<RequestedBookResponse>>(requestedBookDetails);
            return requestedBookData;
        }
        public async Task<RequestedBooks?> SaveRequestAsync(SaveRequestdBook request)
        {
            var requestDetails = _repo.SaveRequestAsync(request);
            return await requestDetails;
        }
    }
}
