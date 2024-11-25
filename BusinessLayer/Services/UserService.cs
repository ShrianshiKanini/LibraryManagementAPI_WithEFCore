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
    public class UserService : IUserService
    {
        private readonly IUserProvider _userProvider;

        public UserService(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        public async Task<IEnumerable<UserDetails>?> GetAllUsers()
        {
            return await _userProvider.GetAllUsers();
        }


        public async Task<Users?> GetUserById(int id)
        {
            return await _userProvider.GetUserById(id);
        }


        public async Task<Users?> GetUserByName(string name)
        {
            return await _userProvider.GetUserByName(name);
        }


        public async Task<Users> AddUser(Users user)
        {
            return await _userProvider.AddUser(user);
        }

        public async Task<Users> UpdateUser(Users user)
        {
            return await _userProvider.UpdateUser(user);
        }

        public async Task<bool> DeleteUserById(int id)
        {
            return await _userProvider.DeleteUserById(id);
        }
    }
}
