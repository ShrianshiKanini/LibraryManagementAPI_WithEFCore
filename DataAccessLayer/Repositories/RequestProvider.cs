using DataAccessLayer.Context;
using DataAccessLayer.DTO;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class RequestProvider:IRequestProvider
    {
        private readonly ApplicationDBContext _context;
        

        public RequestProvider(ApplicationDBContext context)
        {
            _context = context;
            
        }
        public async Task<List<RequestedBookDetails>> GetAllRequestAsync()
        {
            var requestedBooksDetails = from requestedBook in _context.RequestedBooks
                                        join book in _context.Books
                                        on requestedBook.BookId equals book.Id
                                        join user in _context.Users
                                        on requestedBook.UserId equals user.Id
                                        select new RequestedBookDetails
                                        {
                                            Id = requestedBook.Id,
                                            UserId = user.Id,
                                            BookId = book.Id,
                                            BookName = book.Title,
                                            UserName = user.Name,
                                            RequestDate = requestedBook.RequestDate,
                                            Returndate = requestedBook.Returndate,
                                            RequestStatus = requestedBook.RequestStatus
                                        };
            return await requestedBooksDetails.ToListAsync();
        }
        public async Task<RequestedBooks?> SaveRequestAsync(SaveRequestdBook requestDTO)
        {
            if (requestDTO == null)
            {
                throw new ArgumentNullException(nameof(requestDTO));
            }
            else
            {
                var request = new RequestedBooks
                {
                    BookId = requestDTO.BookId,
                    UserId = requestDTO.UserId,
                    RequestDate = requestDTO.RequestDate,
                    Returndate = requestDTO.Returndate,
                    RequestStatus = requestDTO.RequestStatus
                };

                await _context.RequestedBooks.AddAsync(request);
                await _context.SaveChangesAsync();
                return request;
            }
        }
    }
}
