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
    public interface IRequestService
    {
        Task<List<RequestedBookResponse>> GetAllRequestAsync();
        Task<RequestedBooks?> SaveRequestAsync(SaveRequestdBook request);
    }
}
