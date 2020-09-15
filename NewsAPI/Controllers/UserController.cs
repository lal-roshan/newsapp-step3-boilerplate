using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Exceptions;
using System;
using System.Threading.Tasks;
namespace NewsAPI.Controllers
{
    /*
   * As in this assignment, we are working with creating RESTful web service, hence annotate
   * the class with [ApiController] annotation and define the controller level route as per 
   * REST Api standard.
   */
    [Route("/api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /*
        * UserService should  be injected through constructor injection. 
        * Please note that we should not create service object using the new keyword
        */
        readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        /*
        * Example: //GET: api/user
        * Define a handler method which will get the user details by a userId.
        * This handler method should return any one of the status messages basis on
        * different situations: 
        * 1. 200(OK) - If the user details found successfully.
        * 2. 404(NOT FOUND) - If the userprofile with specified userid doesn't exist. 
        * This handler method should map to the URL "/api/user/{userId}" using HTTP GET method
        * 3. 500 (Internal Server Error),means that server cannot process the request 
          for an unknown reason.
        */
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(string userId)
        {
            try
            {
                return Ok(await userService.GetUser(userId));
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Some error occurred, please try again later !!");
            }
        }

        /*
         * Define a handler method which will create a specific user profile by reading the
         * Serialized object from request body and save the user details in a userprofile table
         * in the database.
         * 
         * This handler method should
         * return any one of the status messages basis on different situations: 
         * 1. 201(CREATED) - If the user profile details created successfully. 
         * 2. 409(CONFLICT) - If the userId conflicts
         * This handler method should map to the URL "/api/user" using HTTP POST method
         * 3. 500 (Internal Server Error),means that server cannot process the request 
         *    for an unknown reason.
         */
        [HttpPost]
        public async Task<IActionResult> Post(UserProfile user)
        {
            try
            {
                await userService.AddUser(user);
                return Created("api/user", true);
            }
            catch (UserAlreadyExistsException exc)
            {
                return Conflict(exc.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Some error occurred, please try again later !!");
            }
        }

        /*
         * Define a handler method which will update a specific user by reading the
         * Serialized object from request body and save the updated user details in
         * a userprofile table in database.
         * This handler method should return any one of the status
         * messages basis on different situations: 
         * 1. 200(OK) - If the reminder updated
         * successfully. 
         * 2. 404(NOT FOUND) - If the userprofile with specified userid doesn't exist. 
         * 
         * This handler method should map to the URL "/api/reminder/{id}" using HTTP PUT
         * method.
         * 3. 500(Internal Server Error),means that server cannot process the request 
         *    for an unknown reason.
         */
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, UserProfile user)
        {
            try
            {
                return Ok(await userService.UpdateUser(id, user));
            }
            catch (UserNotFoundException exc)
            {
                return NotFound(exc.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Some error occurred, please try again later !!");
            }
        }
        /*
        * Define a handler method which will delete a user from a database.
        * 
        * This handler method should return any one of the status messages basis on
        * different situations: 
        * 1. 200(OK) - If the user deleted successfully from database. 
        * 2. 404(NOT FOUND)-If the user with specified userrId is not found. 
        * 
        * This handler method should map to the URL "/api/user/{id}" using HTTP Delete
        * method" where "id" should be replaced by a valid userId without {}
        * 3. 500(Internal Server Error),means that server cannot process the request 
        *    for an unknown reason.
        */
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                return Ok(await userService.DeleteUser(id));
            }
            catch (UserNotFoundException exc)
            {
                return NotFound(exc.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Some error occurred, please try again later !!");
            }
        }
    }
}
