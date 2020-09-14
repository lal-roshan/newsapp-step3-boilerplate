using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Exceptions;
using System.Threading.Tasks;
namespace NewsAPI.Controllers
{
    /*
    * As in this assignment, we are working with creating RESTful web service, hence annotate
    * the class with [ApiController] annotation and define the controller level route as per 
    * REST Api standard.
    */
    public class NewsController : ControllerBase
    {
       /*
       * NoteService should  be injected through constructor injection. 
       * Please note that we should not create service
       * object using the new keyword
       */
        public NewsController(INewsService newsService)
        {
            
        }
        /*
         * Example: //GET: api/News
        * Define a handler method which will get the news by a userId.
        * 
        * This handler method should return any one of the status messages basis on
        * different situations: 
        * 1. 200(OK) - If the news found successfully.
        * 
        * This handler method should map to the URL "/api/news/{userId}" using HTTP GET method
        */

        // Example: GET: api/News/3
        /*
        * Define a handler method which will get the news by a userId.
        * 
        * This handler method should return any one of the status messages basis on
        * different situations: 
        * 1. 200(OK) - If the news found successfully.
        * 2. 404(NOT FOUND) - If the news with specified newsId is not found.
        * 3. 500 (Internal Server Error),means that server cannot process the request 
        *    for an unknown reason.
        */

        /*
         * Define a handler method which will create a specific news by reading the
         * Serialized object from request body and save the news details in a News table
         * in the database.
         * 
         * This handler method should
         * return any one of the status messages basis on different situations: 
         * 1. 201(CREATED) - If the news created successfully. 
         * 2. 409(CONFLICT) - If the newsId conflicts
         * This handler method should map to the URL "/api/news" using HTTP POST method
         * 3. 500 (Internal Server Error),means that server cannot process the request 
         *      for an unknown reason.
         */

        /*
        * Define a handler method which will delete a news from a database.
        * 
        * This handler method should return any one of the status messages basis on
        * different situations:
        * 1. 200(OK) - If the news deleted successfully from
        *    database. 
        * 2. 404(NOT FOUND) - If the news with specified newsId is not found.
        *    Note: Its always better to have your own custom Exception to display 
        *    not found exception
        * 
        * This handler method should map to the URL "/api/news/{id}" using HTTP Delete
        * method" where "id" should be replaced by a valid newsId without {}
        * 3. 500 (Internal Server Error),means that server cannot process the request 
        *    for an unknown reason.
        */
    }
}
