using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using System.Threading.Tasks;
using DAL;
using Entities;
using Service;
using Service.Exceptions;

namespace Test.ServiceTests
{
    public class NewsServiceTest
    {
        [Fact]
        public async Task AddNewsShouldReturnNews()
        {
            News news = new News { Title = "chandrayaan2-spacecraft", Content = "The Lander of Chandrayaan-2 was named Vikram after Dr Vikram A Sarabhai", PublishedAt = DateTime.Now, CreatedBy = "Jack" };
            News addednews = new News { NewsId = 103, Title = "chandrayaan2-spacecraft", Content = "The Lander of Chandrayaan-2 was named Vikram after Dr Vikram A Sarabhai", PublishedAt = DateTime.Now, CreatedBy = "Jack" };
            var mockRepo = new Mock<INewsRepository>();
            mockRepo.Setup(repo => repo.IsNewsExist(news)).Returns(Task.FromResult(false));
            mockRepo.Setup(repo => repo.AddNews(news)).Returns(Task.FromResult(addednews));
            var service = new NewsService(mockRepo.Object);

            var actual = await service.AddNews(news);
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<News>(actual);
            Assert.Equal(103, actual.NewsId);
        }


        [Fact]
        public async Task GetAllNewsShouldReturnListOfNews()
        {
            string userId = "Jack";
            var mockRepo = new Mock<INewsRepository>();
            mockRepo.Setup(repo => repo.GetAllNews(userId)).Returns(Task.FromResult(this.newsList));
            var service = new NewsService(mockRepo.Object);

            var actual = await service.GetAllNews(userId);
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<List<News>>(actual);
            Assert.Equal(2, actual.Count);
        }

        [Fact]
        public async Task GetNewsByIdShouldReturnNews()
        {
            int newsId = 101;
            News news = new News { NewsId = 101, Title = "IT industry in 2020", Content = "It is expected to have positive growth in 2020.", PublishedAt = DateTime.Now, UrlToImage = null, CreatedBy = "Jack", Url = null };
            var mockRepo = new Mock<INewsRepository>();
            mockRepo.Setup(repo => repo.GetNewsById(newsId)).Returns(Task.FromResult(news));
            var service = new NewsService(mockRepo.Object);

            var actual = await service.GetNewsById(newsId);
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<News>(actual);
            Assert.Equal("IT industry in 2020", actual.Title);
        }

        [Fact]
        public async Task RemoveNewsShouldSuccess()
        {
            int newsId = 101;
            News news = new News { NewsId = 101, Title = "IT industry in 2020", Content = "It is expected to have positive growth in 2020.", PublishedAt = DateTime.Now, UrlToImage = null, CreatedBy = "Jack", Url = null };
            var mockRepo = new Mock<INewsRepository>();
            mockRepo.Setup(repo => repo.GetNewsById(newsId)).Returns(Task.FromResult(news));
            mockRepo.Setup(repo => repo.RemoveNews(news)).Returns(Task.FromResult(true));
            var service = new NewsService(mockRepo.Object);

            var actual = await service.RemoveNews(newsId);
            Assert.True(actual);
        }

        [Fact]
        public async Task AddNewsShouldThrowException()
        {
            News news = new News { Title = "chandrayaan2-spacecraft", Content = "The Lander of Chandrayaan-2 was named Vikram after Dr Vikram A Sarabhai", PublishedAt = DateTime.Now, CreatedBy = "Jack" };
            var mockRepo = new Mock<INewsRepository>();
            mockRepo.Setup(repo => repo.IsNewsExist(news)).Returns(Task.FromResult(true));
            var service = new NewsService(mockRepo.Object);

            var actual = await Assert.ThrowsAsync<NewsAlreadyExistsException>(() => service.AddNews(news));
            Assert.Equal($"This news is already added", actual.Message);
        }

        [Fact]
        public async Task GetAllNewsShouldThrowException()
        {
            string userId = "Jack";
            var lstnews = new List<News>();
            var mockRepo = new Mock<INewsRepository>();
            mockRepo.Setup(repo => repo.GetAllNews(userId)).Returns(Task.FromResult(lstnews));
            var service = new NewsService(mockRepo.Object);

            var actual = await Assert.ThrowsAsync<NewsNotFoundException>(() => service.GetAllNews(userId));
            Assert.Equal($"No news found for user: {userId}", actual.Message);
        }

        [Fact]
        public async Task GetNewsByIdShouldThrowexception()
        {
            int newsId = 101;
            News news = null;
            var mockRepo = new Mock<INewsRepository>();
            mockRepo.Setup(repo => repo.GetNewsById(newsId)).Returns(Task.FromResult(news));
            var service = new NewsService(mockRepo.Object);

            var actual = await Assert.ThrowsAsync<NewsNotFoundException>(() => service.GetNewsById(newsId));
            Assert.Equal($"No news found with Id: {newsId}", actual.Message);
        }

        [Fact]
        public async Task RemoveNewsShouldThrowException()
        {
            int newsId = 101;
            News news = null;
            var mockRepo = new Mock<INewsRepository>();
            mockRepo.Setup(repo => repo.GetNewsById(newsId)).Returns(Task.FromResult(news));
            var service = new NewsService(mockRepo.Object);

            var actual = await Assert.ThrowsAsync<NewsNotFoundException>(() => service.RemoveNews(newsId));
            Assert.Equal($"No news found with Id: {newsId}", actual.Message);
        }
        List<News> newsList = new List<News>{
            new News { NewsId = 101, Title = "IT industry in 2020", Content = "It is expected to have positive growth in 2020.", PublishedAt = DateTime.Now, UrlToImage = null, CreatedBy = "Jack", Url=null },
            new News {NewsId=102, Title = "2020 FIFA U-17 Women World Cup", Content = "The tournament will be held in India between 2 and 21 November 2020", PublishedAt = DateTime.Now, UrlToImage=null, CreatedBy = "Jack" }
            };
    }
}
