using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DAL
{
    //Inherit the respective interface and implement the methods in
    // this class i.e NewsRepository by inheriting INewsRepository
    public class NewsRepository : INewsRepository
    {
        readonly NewsDbContext dbContext;
        public NewsRepository(NewsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<News> AddNews(News news)
        {
            int newsId = 101;
            if (dbContext.NewsList.Count() > 0)
                newsId = dbContext.NewsList.Max(t => t.NewsId) + 1;
            news.NewsId = newsId;
            await dbContext.NewsList.AddAsync(news);
            await dbContext.SaveChangesAsync();
            return news;
        }

        public async Task<List<News>> GetAllNews(string userId)
        {
            return await dbContext.NewsList.Where(news => string.Equals(news.CreatedBy, userId)).ToListAsync();
        }

        public async Task<News> GetNewsById(int newsId)
        {
            return await dbContext.NewsList.Where(news => news.NewsId == newsId).FirstOrDefaultAsync();
        }

        public async Task<bool> IsNewsExist(News news)
        {
            return await dbContext.NewsList.AnyAsync(n => 
            string.Equals(n.Title, news.Title) &&
            string.Equals(n.Content, news.Content) &&
            string.Equals(n.CreatedBy, news.CreatedBy));
        }

        public async Task<bool> RemoveNews(News news)
        {
            dbContext.NewsList.Remove(news);
            return await dbContext.SaveChangesAsync() > 0;
        }
        /* Implement all the methods of respective interface asynchronously*/
        /* Implement AddNews method to add the new news details*/
        /* Implement GetAllNews method to get the news details of perticular userid*/
        /* Implement GetNewsById method to get the existing news by news id*/
        /* Implement IsNewsExist method to check the news deatils exist or not*/
        /* Implement RemoveNews method to remove the existing news*/
    }
}
