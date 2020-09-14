using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Test
{
    public class DatabaseFixture : IDisposable
    {
        public NewsDbContext context;
        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<NewsDbContext>()
                .UseInMemoryDatabase(databaseName: "NewsDBTest")
                .Options;

            //Initializing DbContext with InMemory
            context = new NewsDbContext(options);

            // Insert seed data into the database using one instance of the context
            SeedData.PopulateTestData(context);
        }
        public void Dispose()
        {
            context = null;
        }
    }

    [CollectionDefinition("Database collection")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
