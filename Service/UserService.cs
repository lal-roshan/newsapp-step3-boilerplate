using DAL;
using Entities;
using Service.Exceptions;
using System.Threading.Tasks;

namespace Service
{
    //Inherit the respective interface and implement the methods in 
    // this class i.e UserService by inheriting IUserService

    // UserService class is used to implement all input validation operations for User CRUD operations

    public class UserService 
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
                
    }
}
