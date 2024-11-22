using DataAccessLayer.DTO;
using DataAccessLayer.Model;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IRequestProvider
    {
        Task<List<RequestedBookDetails>> GetAllRequestAsync();
        Task<RequestedBooks?> SaveRequestAsync(SaveRequestdBook requestDTO);
        //Task<Books> GetRequestByIdAsync(int id);
        //Task<Books?> UpdateRequestAsync(Books book);
        //Task<string?> DeleteRequestAsync(int Id);
    }
}
