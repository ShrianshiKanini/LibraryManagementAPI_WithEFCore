using BusinessLayer.Model;
using DataAccessLayer.DTO;
using DataAccessLayer.Model;


namespace BusinessLayer.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponse>> GetAllBooksAsync();
        Task<Books?> SaveBookAsync(SaveBook book);
        Task<Books> GetBookByIdAsync(int id);
        Task<Books?> UpdateBookAsync(SaveBook book);
        Task<string?> DeleteBookAsync(int Id);

    }
}
