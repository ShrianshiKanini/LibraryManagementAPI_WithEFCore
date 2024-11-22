using AutoMapper;
using BusinessLayer.Model;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.DTO;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLayer.Services
{
    public class BookService:IBookService
    {
        private readonly IBookProvider _repo;
        private readonly IMapper _mapper;

        public BookService(IBookProvider repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<BookResponse>> GetAllBooksAsync()
        {
            var bookDetails = await _repo.GetAllBooksAsync();
            var bookData = _mapper.Map<List<BookResponse>>(bookDetails);
            return bookData;
        }

        public async Task<Books?> SaveBookAsync(SaveBook book)
        {
            var bookDetails = _repo.SaveBookAsync(book);
            return await bookDetails;
        }

        public async Task<Books> GetBookByIdAsync(int id)
        {
            var bookDetails = _repo.GetBookByIdAsync(id);
            return await bookDetails;
        }

        public async Task<Books?> UpdateBookAsync(SaveBook book)
        {
            var bookDetails = _repo.UpdateBookAsync(book);
            return await bookDetails;
        }

        public async Task<string?> DeleteBookAsync(int Id)
        {
            var bookDetails = _repo.DeleteBookAsync(Id);
            return await bookDetails;
        }
    }
}
