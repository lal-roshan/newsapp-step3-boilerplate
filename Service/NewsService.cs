using DAL;
using Entities;
using Service.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    //Inherit the respective interface and implement the methods in 
    // this class i.e NewsService by inheriting INewsService

    // NewsService class is used to implement all input validation operations for News CRUD operations

    public class NewsService
    {
        /*
         * this service depends on NewsRepository instance for the crud operations
         */



        /*
         * Implement AddNews() method which should be used to 
         * save a new News, provided the news does not exist, 
         * else should throw NewsAlreadyExistsException
         */


        /*
         * Implement GetAllNews() method which should be used to 
         * get all news details for the provided userId,
         * however, should throw NewsNotFoundException if no news exist for the provided userId
         */


        /*
         * Implement GetNewsById() method which should be used to 
         * get complete news details for the provided newsId,
         * however, should throw NewsNotFoundException if no news exist for the provided newsId
         */


        /*
         * Implement RemoveNews() method which should be used to 
         * delete an existing news
         * however, should throw NewsNotFoundException if news with provided newsId does not exist         * 
         */

    }
}
