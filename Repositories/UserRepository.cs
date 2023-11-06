using Entities;
using Microsoft.EntityFrameworkCore;
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

        private const string filePath = "E:\\מסלול_תשפד\\Web_Api\\MyFirstWebApiSite\\Users";
        public  async Task<UsersTbl> addUserToDB(UsersTbl user)
        {
            await _store214358897Context.UsersTbls.AddAsync(user);
            await _store214358897Context.SaveChangesAsync();
            return user;
        }

        public async Task<UsersTbl> getUserByEmailAndPassword(string email, string password)
        {
            //using (StreamReader reader = System.IO.File.OpenText(filePath))
            //{
            //    string? currentUserInFile;
            //    while ((currentUserInFile =  await reader.ReadLineAsync()) != null)
            //    {
            //        UsersTbl user = JsonSerializer.Deserialize<UsersTbl>(currentUserInFile);
            //        if (user.Email == email && user.Password == password)
            //            return user;
            //    }
            //}
            //await _store214358897Context.UsersTbls.FindAsync(email);

            return await _store214358897Context.UsersTbls.FindAsync(email);
        }

        public  async Task<bool> updateUserDetails(int id, UsersTbl userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile =  await reader.ReadLineAsync()) != null)
                {

                    UsersTbl user = JsonSerializer.Deserialize<UsersTbl>(currentUserInFile);
                    if (user.UserId == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = await System.IO.File.ReadAllTextAsync(filePath);
                text =  text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(filePath, text);
                return true;
            }
            return false;
        }

    }
}