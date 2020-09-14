using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Test.RepositoryTests
{
    [Collection("Database collection")]
    [TestCaseOrderer("Test.PriorityOrderer", "test")]
    public class NewsRepositoryTest
    {
        private readonly NewsRepository repository;
        public NewsRepositoryTest(DatabaseFixture fixture)
        {
            repository = new NewsRepository(fixture.context);
        }

        [Fact, TestPriority(1)]
        public async Task AddNewsShouldSuccess()
        {
            News news = new News { Title = "chandrayaan2-spacecraft", Content = "The Lander of Chandrayaan-2 was named Vikram after Dr Vikram A Sarabhai", PublishedAt = DateTime.Now, CreatedBy = "Jack" };

            var actual =await repository.AddNews(news);
            Assert.IsAssignableFrom<News>(actual);
            Assert.Equal(103, actual.NewsId);
        }

        [Fact, TestPriority(2)]
        public async Task GetAllNewsShouldReturnList()
        {
            string userId = "Jack";
            var actual = await repository.GetAllNews(userId);
            Assert.IsAssignableFrom<List<News>>(actual);
            Assert.Equal(3, actual.Count);
        }

        [Fact, TestPriority(3)]
        public async Task GetNewsByIdShouldReturnNews()
        {
            int newsId = 101;
            var actual = await repository.GetNewsById(newsId);
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<News>(actual);
            Assert.Equal("IT industry in 2020",actual.Title);
        }

        [Fact, TestPriority(4)]
        public async Task IsNewsExistShouldSuccess()
        {
            News news = new News { Title = "2020 FIFA U-17 Women World Cup", Content = "The tournament will be held in India between 2 and 21 November 2020", PublishedAt = DateTime.Now, CreatedBy = "Jack" };

            var actual = await repository.IsNewsExist(news);
            Assert.True(actual);
        }

        [Fact, TestPriority(5)]
        public async Task RemoveNewsShouldSuccess()
        {
            int newsId = 103;
            var actual = await repository.GetNewsById(newsId);
            Assert.NotNull(actual);

            var deleted = await repository.RemoveNews(actual);
            Assert.True(deleted);
        }

        [Fact, TestPriority(6)]
        public async Task GetNewsByIdShouldReturnNull()
        {
            int newsId = 104;
            var actual = await repository.GetNewsById(newsId);
            Assert.Null(actual);
        }

        [Fact, TestPriority(7)]
        public async Task IsNewsExistShouldFail()
        {
            News news = new News { Title = "Sample News", Content = null, PublishedAt = DateTime.Now, CreatedBy = "Jack" };

            var actual = await repository.IsNewsExist(news);
            Assert.False(actual);
        }
    }
}
