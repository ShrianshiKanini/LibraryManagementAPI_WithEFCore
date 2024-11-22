using DataAccessLayer.DTO;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IBookProvider
    {
        Task<IEnumerable<BookDetails>> GetAllBooksAsync();
        Task<Books?> SaveBookAsync(SaveBook book);
        Task<Books> GetBookByIdAsync(int id);
        Task<Books?> UpdateBookAsync(SaveBook book);
        Task<string?> DeleteBookAsync(int id);
    }
}
