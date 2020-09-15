﻿using Entities;
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
    public class NewsController : ControllerBase
    {
        /*
        * NoteService should  be injected through constructor injection. 
        * Please note that we should not create service
        * object using the new keyword
        */
        readonly INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
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
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(string userId)
        {
            try
            {
                return Ok(await newsService.GetAllNews(userId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

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
        [HttpGet("{newsId:int}")]
        public async Task<IActionResult> Get(int newsId)
        {
            try
            {
                return Ok(await newsService.GetNewsById(newsId));
            }
            catch (NewsNotFoundException exc)
            {
                return NotFound(exc.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Some error occurred, please try again later !!");
            }
        }

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
        [HttpPost]
        public async Task<IActionResult> Post(News news)
        {
            try
            {
                news = await newsService.AddNews(news);
                return Created("api/news",news);
            }
            catch(NewsAlreadyExistsException exc)
            {
                return Conflict(exc.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Some error occurred, please try again later !!");
            }
        }
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await newsService.RemoveNews(id));
            }
            catch (NewsNotFoundException exc)
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
