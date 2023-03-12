using sunum2.API.Models;
using System.Collections;

namespace sunum2.API.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserByID(int ID);
        Task<User> CreateUser(User User);
        Task<User> UpdateUser(User User);
        bool DeleteUser(int ID);
    }
}
