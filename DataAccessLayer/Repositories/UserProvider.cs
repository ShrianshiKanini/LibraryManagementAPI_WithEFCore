using DataAccessLayer.Context;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserProvider : IUserProvider
    {

        private readonly ApplicationDBContext _context;


        public UserProvider(ApplicationDBContext context)
        {
            _context = context;
        }

       public async Task<IEnumerable<Users>?> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
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
