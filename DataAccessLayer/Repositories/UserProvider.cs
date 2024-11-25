using DataAccessLayer.Context;
using DataAccessLayer.DTO;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace DataAccessLayer.Repositories
{
    public class UserProvider : IUserProvider
    {

        private readonly ApplicationDBContext _context;


        public UserProvider(ApplicationDBContext context)
        {
            _context = context;
        }

       public async Task<IEnumerable<UserDetails>?> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();

            // Fetch all requested books
            var requestedBooks = await _context.RequestedBooks.ToListAsync();

            var books = await _context.Books.ToListAsync();

            // Map users with their respective requested books
            var usersWithBooks = users.Select(user => new UserDetails
            {
                Id = user.Id,
                Name = user.Name,
                Role = user.Role,
                Email = user.Email,
                RequestedBooks = requestedBooks
                    .Where(rb => rb.UserId == user.Id) // Filter books by UserId
                    .Select(rb => new RequestedBookDetails
                    {
                        UserId = rb.UserId,
                        BookId = rb.BookId,
                        UserName = user.Name,
                        BookName = books.FirstOrDefault(b => b.Id == rb.BookId)?.Title,
                        RequestDate = rb.RequestDate,
                        ReturnDate = rb.Returndate,
                        RequestStatus = rb.RequestStatus
                    })
                    .ToList()
            }).ToList();

            return usersWithBooks;

        }


        public async Task<Users?> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<Users?> GetUserByName(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(s => s.Name.Contains(name));
        }

        public async Task<Users> AddUser(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Users> UpdateUser(Users user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
