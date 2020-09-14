using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace DAL
{
    //Inherit the respective interface and implement the methods in 
    // this class i.e UserRepository by inheriting IUserRepository

    // UserRepository class is used to implement all Data access operations
    public class UserRepository: IUserRepository
    {
        readonly NewsDbContext dbContext;
        public UserRepository(NewsDbContext dbContext)
        {
            this.dbContext = dbContext;
            // Implement AddUser method which should be used to save a new user.   
            // Implement DeleteUser method which should be used to delete an existing user.
            // Implement GetUser method which should be used to get a userprofile complete detail by userId.
            // Implement UpdateUser method which should be used to update an existing user.
        }

        public async Task<bool> AddUser(UserProfile user)
        {
            await dbContext.Users.AddAsync(user);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteUser(UserProfile user)
        {
            dbContext.Users.Remove(user);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<UserProfile> GetUser(string userId)
        {
            return await dbContext.Users.Where(user => string.Equals(user.UserId, userId)).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateUser(UserProfile user)
        {
            var presentUser = await GetUser(user.UserId);
            if(presentUser != null)
            {
                presentUser.FirstName = user.FirstName;
                presentUser.LastName = user.LastName;
                presentUser.Contact = user.Contact;
                presentUser.Email = user.Email;
                presentUser.CreatedAt = user.CreatedAt;
            }
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
