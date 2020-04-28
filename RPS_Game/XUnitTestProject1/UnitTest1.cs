using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using RPS_Game;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<RPS_DbContext>()
                .UseInMemoryDatabase(databaseName: "Test1").Options;

            //Act
            using (var db = new RPS_DbContext(options)) ;

            //Assert
        }

        [Fact]
        public void Test2()
        {

        }


    }
}
