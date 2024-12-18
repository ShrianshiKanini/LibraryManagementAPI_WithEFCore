﻿

using DataAccessLayer.Context;
using DataAccessLayer.DTO;
using DataAccessLayer.Model;
using Microsoft.Extensions.Logging;

namespace DataAccessLayer.Repositories.Interfaces
{

    public interface IUserProvider
    {
        Task<IEnumerable<UserDetails>?> GetAllUsers();
        Task<Users?> GetUserById(int id);

        Task<Users?> GetUserByName(string name);
        Task<Users> AddUser(Users user);
        Task<Users> UpdateUser(Users user);
        Task<bool> DeleteUserById(int id);      
    }
}
