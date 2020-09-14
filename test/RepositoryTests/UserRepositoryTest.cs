using DAL;
using Entities;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Test.RepositoryTests
{
    [Collection("Database collection")]
    public class UserRepositoryTest
    {
        private readonly UserRepository repository;
        public UserRepositoryTest(DatabaseFixture fixture)
        {
            repository = new UserRepository(fixture.context);
        }

        [Fact]
        public async Task AddUserShouldSuccess()
        {
            UserProfile user = new UserProfile { UserId = "John", FirstName = "Johnson", LastName = "dsouza", Contact = "7869543210", Email = "john@gmail.com", CreatedAt = DateTime.Now };

            var actual =await repository.AddUser(user);
            Assert.True(actual);

            var _user =await repository.GetUser("John");
            Assert.IsAssignableFrom<UserProfile>(_user);
            Assert.Equal("Johnson", _user.FirstName);
        }

        [Fact]
        public async Task DeleteUserShouldSuccess()
        {
            var _user = await repository.GetUser("Jack");
            var actual = await repository.DeleteUser(_user);
            Assert.True(actual);
        }

        [Fact]
        public async Task UpdateUserShouldSuccess()
        {
            var user = await repository.GetUser("Jack");
            user.Contact = "9988776655";
            var actual = await repository.UpdateUser(user);
            Assert.True(actual);

            var _user= await repository.GetUser("Jack");
            Assert.Equal("9988776655", _user.Contact);
        }

    }
}
