

using DataAccessLayer.Context;
using DataAccessLayer.Model;
using Microsoft.Extensions.Logging;

namespace DataAccessLayer.Repositories.Interfaces
{

    public interface IUserProvider
    {
        Task<IEnumerable<Users>?> GetAllUsers();
        Task<Users?> GetUserById(int id);

        Task<Users?> GetUserByName(string name);
        Task<Users> AddUser(Users user);
        Task<Users> UpdateUser(Users user);
        Task<bool> DeleteUserById(int id);      
    }
}
