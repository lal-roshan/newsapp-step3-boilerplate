using DAL;
using Entities;
using Service.Exceptions;
using System.Threading.Tasks;

namespace Service
{
    //Inherit the respective interface and implement the methods in 
    // this class i.e UserService by inheriting IUserService

    // UserService class is used to implement all input validation operations for User CRUD operations

    public class UserService : IUserService
    {
        /*
         * this service depends on UserRepository instance for the crud operations
         */



        /*
         * Implement AddUser() method which should be used to 
         * save a new user, provided the UserId does not exist, 
         * else should throw UserAlreadyExistsException
         */



        /*
         * Implement DeleteUser() method which should be used to 
         * delete an existing user,
         * however, should throw UserNotFoundException if User with provided userId does not exist         * 
         */



        /*
         * Implement GetUser() method which should be used to 
         * get complete userprofile details by userId,
         * however, should throw UserNotFoundException if User with provided userId does not exist
         */


        /*
         * Implement UpdateUser() method which should be used to 
         * update email and contact details for existing user,
         * however, should throw UserNotFoundException if User with provided userId does not exist
         */
        readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> AddUser(UserProfile user)
        {
            var presentUser = await repository.GetUser(user.UserId);
            if(presentUser == null)
            {
                return await repository.AddUser(user);
            }
            throw new UserAlreadyExistsException($"{user.UserId} already exists");
        }

        public async Task<bool> DeleteUser(string userId)
        {
            var user = await repository.GetUser(userId);
            if(user != null)
            {
                return await repository.DeleteUser(user);
            }
            throw new UserNotFoundException(userId);
        }

        public async Task<UserProfile> GetUser(string userId)
        {
            var user = await repository.GetUser(userId);
            if (user != null)
            {
                return user;
            }
            throw new UserNotFoundException(userId);
        }

        public async Task<bool> UpdateUser(string userId, UserProfile user)
        {
            bool updated = await repository.UpdateUser(user);
            if (updated)
            {
                return updated;
            }
            throw new UserNotFoundException(userId);
        }
    }
}
