using Entities;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Store214358897Context _store214358897Context;

        public UserRepository(Store214358897Context store214358897Context)
        {
            _store214358897Context = store214358897Context;
        }

        //public async Task<IEnumerable<UsersTbl>> GetUsersAsync()
        //{
        //    return await _store214358897Context.UsersTbls.ToListAsync();
        //}

       
        public  async Task<UsersTbl> addUserToDB(UsersTbl user)
        {
            await _store214358897Context.UsersTbls.AddAsync(user);
            await _store214358897Context.SaveChangesAsync();
            return user;
        }

        public async Task<UsersTbl> getUserByEmailAndPassword(string email, string password)
        {

            return await _store214358897Context.UsersTbls.Where(p => p.Email == email & p.Password == password)
                .FirstOrDefaultAsync();
        }

// ----לא עובד מצריך בדיקה----
        public async Task updateUserDetails(int id, UsersTbl userToUpdate)
        {
             _store214358897Context.UsersTbls.Update(userToUpdate);
            await _store214358897Context.SaveChangesAsync();
            
// ----לא עובד מצריך בדיקה----
        }

    }
}