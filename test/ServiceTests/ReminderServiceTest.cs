using System;
using Xunit;
using Moq;
using System.Threading.Tasks;
using Entities;
using DAL;
using Service;
using Service.Exceptions;

namespace Test.ServiceTests
{
    public class ReminderServiceTest
    {
        [Fact]
        public async Task AddReminderShouldReturnReminder()
        {
            Reminder reminder = new Reminder { NewsId = 102, Schedule = DateTime.Now.AddDays(1) };
            Reminder addedReminder = new Reminder { ReminderId = 2, NewsId = 102, Schedule = DateTime.Now.AddDays(1) };
            Reminder _reminder = null;
            var mockRepo = new Mock<IReminderRepository>();
            mockRepo.Setup(repo => repo.GetReminderByNewsId(reminder.NewsId)).Returns(Task.FromResult(_reminder));
            mockRepo.Setup(repo => repo.AddReminder(reminder)).Returns(Task.FromResult(addedReminder));
            var service = new ReminderService(mockRepo.Object);

            var actual =await service.AddReminder(reminder);
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<Reminder>(actual);
            Assert.Equal(2, actual.ReminderId);
        }

        [Fact]
        public async Task GetReminderByNewsIdShouldReturnReminder()
        {
            int newsId = 102;
            Reminder reminder = new Reminder {ReminderId=2, NewsId = 102, Schedule = DateTime.Now.AddDays(1) };
            var mockRepo = new Mock<IReminderRepository>();
            mockRepo.Setup(repo => repo.GetReminderByNewsId(newsId)).Returns(Task.FromResult(reminder));
            var service = new ReminderService(mockRepo.Object);

            var actual = await service.GetReminderByNewsId(newsId);
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<Reminder>(actual);
            Assert.Equal(2, actual.ReminderId);
        }
        [Fact]
        public async Task GetReminderByNewsIdShouldThrowException()
        {
            int newsId = 102;
            Reminder reminder = null;
            var mockRepo = new Mock<IReminderRepository>();
            mockRepo.Setup(repo => repo.GetReminderByNewsId(newsId)).Returns(Task.FromResult(reminder));
            var service = new ReminderService(mockRepo.Object);

            var actual = await Assert.ThrowsAsync<ReminderNotFoundException>(() => service.GetReminderByNewsId(newsId));
            Assert.Equal($"No reminder found for news: {newsId}", actual.Message);
        }

        [Fact]
        public async Task RemoveReminderShouldSuccess()
        {
            int reminderId = 2;
            Reminder reminder = new Reminder { ReminderId = 2, NewsId = 102, Schedule = DateTime.Now.AddDays(1) };
            var mockRepo = new Mock<IReminderRepository>();
            mockRepo.Setup(repo => repo.GetReminder(reminderId)).Returns(Task.FromResult(reminder));
            mockRepo.Setup(repo => repo.RemoveReminder(reminder)).Returns(Task.FromResult(true));
            var service = new ReminderService(mockRepo.Object);

            var actual = await service.RemoveReminder(reminderId);
            Assert.True(actual);
        }

        [Fact]
        public async Task RemoveReminderShouldThrowException()
        {
            int reminderId = 3;
            Reminder reminder = null;
            var mockRepo = new Mock<IReminderRepository>();
            mockRepo.Setup(repo => repo.GetReminder(reminderId)).Returns(Task.FromResult(reminder));
            var service = new ReminderService(mockRepo.Object);

            var actual = await Assert.ThrowsAsync<ReminderNotFoundException>(() => service.RemoveReminder(reminderId));
            Assert.Equal($"No reminder found with id: {reminderId}", actual.Message);
        }

        [Fact]
        public async Task AddReminderShouldThrowException()
        {
            int newsId = 101;
            Reminder reminder = new Reminder {NewsId=101, Schedule=DateTime.Now.AddDays(2) };
            var mockRepo = new Mock<IReminderRepository>();
            mockRepo.Setup(repo => repo.GetReminderByNewsId(newsId)).Returns(Task.FromResult(reminder));
            var service = new ReminderService(mockRepo.Object);

            var actual = await Assert.ThrowsAsync<ReminderAlreadyExistsException>(()=> service.AddReminder(reminder));
            Assert.Equal($"This news: {newsId} already have a reminder", actual.Message);
        }
    }
}
