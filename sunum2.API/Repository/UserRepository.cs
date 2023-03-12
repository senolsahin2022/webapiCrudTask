using Microsoft.EntityFrameworkCore;
using sunum2.API.Models;
using sunum2.API.Repository.Interfaces;

namespace sunum2.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SunumdbContext _sunumdbContext;

        public UserRepository(SunumdbContext sunumdbContext)
        {
            _sunumdbContext = sunumdbContext;
        }

        public async Task<User> CreateUser(User User)
        {
            _sunumdbContext.Users.Add(User);
            await _sunumdbContext.SaveChangesAsync();
            return User;
        }

        public bool DeleteUser(int ID)
        {
            bool result = false;
            var User = _sunumdbContext.Users.Find(ID);
            if (User != null)
            {
                _sunumdbContext.Entry(User).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _sunumdbContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public async Task<User> GetUserByID(int ID)
        {
            return await _sunumdbContext.Users.FindAsync(ID);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _sunumdbContext.Users.ToListAsync();
        }

        public async Task<User> UpdateUser(User User)
        {
            _sunumdbContext.Entry(User).State = EntityState.Modified; 
            await _sunumdbContext.SaveChangesAsync();
            return User;
        }
    }
}
