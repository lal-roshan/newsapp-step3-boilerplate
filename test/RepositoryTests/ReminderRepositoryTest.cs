using DAL;
using Entities;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Test.RepositoryTests
{
    [Collection("Database collection")]
    [TestCaseOrderer("Test.PriorityOrderer", "test")]
    public class ReminderRepositoryTest
    {
        private readonly ReminderRepository repository;
        public ReminderRepositoryTest(DatabaseFixture fixture)
        {
            repository = new ReminderRepository(fixture.context);
        }

        [Fact, TestPriority(1)]
        public async Task AddReminderShouldSuccess()
        {
            Reminder reminder = new Reminder {NewsId=102, Schedule=DateTime.Now.AddHours(20)  };

            var actual = await repository.AddReminder(reminder);
            Assert.IsAssignableFrom<Reminder>(actual);
            Assert.Equal(2, actual.ReminderId);
        }

        [Fact, TestPriority(2)]
        public async Task GetReminderShouldReturnReminder()
        {
            int reminderId = 2;

            var actual = await repository.GetReminder(reminderId);
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<Reminder>(actual);
            Assert.Equal(102, actual.NewsId);
        }

        [Fact, TestPriority(3)]
        public async Task GetReminderByNewsIdShouldReturnReminder()
        {
            int newsId = 101;

            var actual = await repository.GetReminderByNewsId(newsId);
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<Reminder>(actual);
            Assert.Equal(1, actual.ReminderId);
        }

        [Fact, TestPriority(4)]
        public async Task RemoveReminderShouldSuccess()
        {
            int reminderId = 2;

            var reminder = await repository.GetReminder(reminderId);
            Assert.NotNull(reminder);

            var actual = await repository.RemoveReminder(reminder);
            Assert.True(actual);
        }

        [Fact, TestPriority(5)]
        public async Task GetReminderShouldReturnNull()
        {
            int reminderId = 2;

            var actual = await repository.GetReminder(reminderId);
            Assert.Null(actual);
        }

        [Fact, TestPriority(6)]
        public async Task GetReminderByNewsIdShouldReturnNull()
        {
            int newsId = 102;

            var actual = await repository.GetReminderByNewsId(newsId);
            Assert.Null(actual);
        }
    }
}
