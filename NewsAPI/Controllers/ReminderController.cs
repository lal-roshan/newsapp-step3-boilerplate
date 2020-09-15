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
    public class ReminderController : ControllerBase
    {
        /*
       * ReminderService should  be injected through constructor injection. 
       * Please note that we should not create service
       * object using the new keyword
       */
        readonly IReminderService reminderService;

        public ReminderController(IReminderService reminderService)
        {
            this.reminderService = reminderService;
        }

        /*
         * Define a handler method which will get us the reminders by a newsId.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations:
         * 1. 200(OK) - If the reminder found successfully.
         * 2. 404(NOT FOUND) - If the reminder with specified reminderId is
         *    not found. 
         * 3. 500(Internal Server Error),means that server cannot process the request 
         *    for an unknown reason.
         * This handler method should map to the URL "/api/reminder/{newsId}" using HTTP GET method
         */
        [HttpGet("{newsId:int}")]
        public async Task<IActionResult> Get(int newsId)
        {
            try
            {
                return Ok(await reminderService.GetReminderByNewsId(newsId));
            }
            catch (ReminderNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Some error occurred, please try again later !!");
            }
        }

        /*
         * Define a handler method which will create a specific reminder by reading the
         * Serialized object from request body and save the reminder details in a reminder table
         * in the database.
         * 
         * This handler method should return any one of the status messages basis on different situations: 
         * 1. 201(CREATED) - In case of successful creation of the reminder 
 
         * 2. 409(CONFLICT) - In case of duplicate reminder ID
         * This handler method should map to the URL "/api/reminder" using HTTP POST method
         * 
         * 3. 500(Internal Server Error),means that server cannot process the request 
         *      for an unknown reason.
         */
        [HttpPost]
        public async Task<IActionResult> Post(Reminder reminder)
        {
            try
            {
                reminder = await reminderService.AddReminder(reminder);
                return Created("api/reminder", reminder);
            }
            catch (ReminderAlreadyExistsException exc)
            {
                return Conflict(exc.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Some error occurred, please try again later !!");
            }
        }

        /*
         * Define a handler method which will delete a reminder from a database.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 
         * 1. 200(OK) - If the reminder deleted successfully from
         * database. 
         * 2. 404(NOT FOUND) - If the reminder with specified reminderId is
         * not found. 
         * 
         * This handler method should map to the URL "/api/reminder/{id}" using HTTP Delete
         * method" where "id" should be replaced by a valid reminderId without {}
         */
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await reminderService.RemoveReminder(id));
            }
            catch (ReminderNotFoundException exc)
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
