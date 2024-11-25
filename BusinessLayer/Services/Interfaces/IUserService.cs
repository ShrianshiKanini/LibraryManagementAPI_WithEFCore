using DataAccessLayer.DTO;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public  interface IUserService
    {
        Task<IEnumerable<UserDetails>?> GetAllUsers();

        Task<Users?> GetUserById(int id);
        Task<Users?> GetUserByName(string name);
        Task<Users> AddUser(Users user);
        Task<Users> UpdateUser(Users user);
        Task<bool> DeleteUserById(int id);
    }
}
