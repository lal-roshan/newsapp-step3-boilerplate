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

    public class NewsService : INewsService
    {
        /*
         * this service depends on NewsRepository instance for the crud operations
         */
        readonly INewsRepository repository;

        public NewsService(INewsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<News> AddNews(News news)
        {
            var presentNews = repository.GetNewsById(news.NewsId);
            if (presentNews == null)
            {
                return await repository.AddNews(news);
            }
            throw new NewsAlreadyExistsException();
        }

        public async Task<List<News>> GetAllNews(string userId)
        {
            var newsList = await repository.GetAllNews(userId);
            if(newsList.Count > 0)
            {
                return newsList;
            }
            throw new NewsNotFoundException(userId);
        }

        public async Task<News> GetNewsById(int newsId)
        {
            var news = await repository.GetNewsById(newsId);
            if(news != null)
            {
                return news;
            }
            throw new NewsNotFoundException(newsId);
        }

        public async Task<bool> RemoveNews(int newsId)
        {
            var news = await repository.GetNewsById(newsId);
            if(news != null)
            {
                return await repository.RemoveNews(news);
            }
            throw new NewsNotFoundException(newsId);
        }

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
