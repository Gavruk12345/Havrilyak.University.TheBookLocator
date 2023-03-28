/*
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWise.Database.Service;
using WorkWise.Databases;

namespace WorkWise.Test
{
    public class MyServiceTests
    {
        [Fact]
        public void MyService_Should_Return_Something()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase(databaseName: "MyDatabase")
                .Options;

            var dbContext = new StoreDbContext(options);

            var service = new CustomerService(dbContext);

            // Act
            var result = service.DoSomething();

            // Assert
            Assert.NotNull(result);
        }
    }
}*/