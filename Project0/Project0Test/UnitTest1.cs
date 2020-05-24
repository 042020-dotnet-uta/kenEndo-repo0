using Microsoft.EntityFrameworkCore;
using Project0;
using Project0.RegiAndLoginFunc;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Xunit;

namespace Project0Test
{
    public class UnitTest1
    {
        /// <summary>
        /// Adds location to database.
        /// tests if it is stored correctly and retrievable
        /// </summary>
        [Fact]
        public void CheckAddsLocationToDbTestPersist()
        {
            //Test1
            //Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Test1")
                .Options;

            //Act
            using(var dbx = new AppDbContext(options))
            {
                dbx.StoreLocations.Add(new StoreLocation { Location = "Houston" }); // adds location to the table
                dbx.StoreLocations.Add(new StoreLocation { Location = "Dallas" });
                dbx.SaveChanges();
            }

            //Assert
            using(var dbx = new AppDbContext(options))
            {
                Assert.Equal(2, dbx.StoreLocations.Count()); // counts the total locations in the location table
                Assert.Equal("Houston", dbx.StoreLocations.First(x=>x.StoreLocationId==1).Location); // select the first location in table
            }
        }
        /// <summary>
        /// Adds user to the database.
        /// Test if the user is stored properly and retrievable
        /// </summary>
        [Fact]
        public void CheckAddsUserToDbTestPersist()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Test2")
                .Options;
            //Act
            using (var db1 = new AppDbContext(options))
            {
                UserInfo newUser = new UserInfo() //adds user to the table
                {
                    fName = "David",
                    lName = "Leblanc",
                    userName = "Davidl",
                    password = "abc123"
                };
                UserInfo newUser1 = new UserInfo()
                {
                    fName = "James",
                    lName = "Jones",
                    userName = "jamesj",
                    password = "abc123"
                };
                db1.Add(newUser);
                db1.Add(newUser1);
                db1.SaveChanges();
            }

            //Assert
            using (var db1 = new AppDbContext(options))
            {
                Assert.Equal("David", db1.UserInfos.First().fName); //check if first username is correct
                Assert.Equal(2, db1.UserInfos.Count()); //cecks the total count of users in user table
            }
        }
        /// <summary>
        /// test if item can be accessed properly from database
        /// </summary>
        [Fact]
        public void AccessingAndRetrievingItem()
        {
            //Test1
            //Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Test3")
                .Options;
            //Act
            using (var dbww = new AppDbContext(options))
            {
                StoreLocation storeLocation = new StoreLocation() // inserts location
                {
                    Location = "Houston"
                };

                StoreItem storeItem = new StoreItem() // inserts item
                {
                    itemName = "Chicken",
                    itemPrice = 5
                };
                StoreItem storeItem1 = new StoreItem() 
                {
                    itemName = "Pork",
                    itemPrice = 10
                };

                storeItem.StoreLocation = storeLocation;
                storeItem1.StoreLocation = storeLocation;
                dbww.StoreLocations.Add(storeLocation);
                dbww.StoreItems.Add(storeItem);
                dbww.StoreItems.Add(storeItem1);
                dbww.SaveChanges();
            }

            //Assert
            using (var dbww = new AppDbContext(options))
            {
                int input1 = 1;
                Assert.Equal("Chicken", dbww.StoreItems //retrieves item name from item #
                    .First(x => x.StoreItemId == input1).itemName);
                Assert.Equal("Houston", dbww.StoreLocations.Include(x => x.StoreItems) //retrieve location from location #
                    .First(x => x.StoreLocationId == input1).Location);
            }
        }




        /// <summary>
        /// test to see if the if loop is working properly when user enter 'y'
        /// </summary>
        [Fact]
        public void YesNoIfStatementLoopCheck()
        {

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Test4")
                .Options;

            //Act
            using (var db9 = new AppDbContext(options))
            {
                bool loopConditionForQuantity = true; //tests the if stagement for user to enter 'y'
                bool trueFalse = false;
                string yesNo = "y";
               
                    while (loopConditionForQuantity) {
                    if (yesNo == "Y" || yesNo == "y") 
                    {
                        loopConditionForQuantity = false;
                        trueFalse = true;                 
                    }
                }

            //Assert
                Assert.True(trueFalse);
            }
        }
        /// <summary>
        /// Tests if the user login class if working properly 
        /// with the input validation
        /// </summary>
        [Fact]
        public void CheckUserLogin()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Test5")
                .Options;
            string userName = "Davidl";
            string password = "abc123";
            string wrongUserName = "Davidabc";
            bool trueFalse = true;
            bool trueFalse1 = true;

            //Act
            using (var db2 = new AppDbContext(options))
            {
                UserInfo newUser = new UserInfo()
                {
                    fName = "David",
                    lName = "Leblanc",
                    userName = "Davidl",
                    password = "abc123"
                };
                UserInfo newUser1 = new UserInfo()
                {
                    fName = "James",
                    lName = "Jones",
                    userName = "jamesj",
                    password = "abc123"
                };
                db2.Add(newUser);
                db2.Add(newUser1);
                db2.SaveChanges();
                try
                {
                    db2.UserInfos.First(u => u.userName == userName && u.password == password); //checks if username matches database
                }
                catch
                {
                    trueFalse = false;
                };
                try
                {
                    db2.UserInfos.First(u => u.userName == wrongUserName && u.password == password);//check if exception will be thrown if wrong
                }
                catch
                {
                    trueFalse1 = false;
                };
            }
            //Assert
            using (var db2 = new AppDbContext(options))
            {
                Assert.True(trueFalse);
                Assert.False(trueFalse1);
            }
        }
        /// <summary>
        /// Test to see if query is written corrently and also if the correct information is 
        /// being retrieved from the database
        /// </summary>
        [Fact]
        public void NavigatingFromLocationToItems()
        {

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Test6")
                .Options;
            int inputLocation = 1;
            int inputItem = 1;
            bool trueFalse = false;
            bool trueFalse1 = false;


            //Act
            using (var db3 = new AppDbContext(options))
            {
                StoreLocation storeLocation = new StoreLocation()
                {
                    Location = "Houston"
                };
                StoreItem storeItem = new StoreItem()
                {
                    itemName = "Chicken",
                    itemPrice = 5
                };
                storeItem.StoreLocation = storeLocation;
                db3.StoreLocations.Add(storeLocation);
                db3.StoreItems.Add(storeItem);
                db3.SaveChanges();

                var dbLocation = db3.StoreLocations.Where(y => y.StoreLocationId == inputLocation)
                    .First().Location;
                if (dbLocation == "Houston") trueFalse = true; //checks if input returns the location
                var dbItem = db3.StoreItems.Where(x => x.StoreItemId == inputItem)
                    .Include(y => y.StoreItemInventory).ToList().First().itemName;
                if (dbItem == "Chicken") trueFalse1 = true; //checks if input returns the item
            }

            //Assert
            using (var db3 = new AppDbContext(options))
            { 
                Assert.True(trueFalse);
                Assert.True(trueFalse1);
            }
        }
        /// <summary>
        /// testing to check if the inputted order quantity is below store inventory
        /// </summary>
        [Fact]
        public void CheckingInputQuantityBelowItemInventory()
        {
            //Test1
            //Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Test7")
                .Options;

            int inputQuantity = 4;
            int inputItem = 1;
            bool trueFalse = false;

            //Act
            using (var db4 = new AppDbContext(options))
            {
                StoreLocation storeLocation = new StoreLocation()
                {
                    Location = "Houston"
                };
                StoreItemInventory storeItemInventory = new StoreItemInventory()
                {
                    itemInventory = 10
                };
                StoreItem storeItem = new StoreItem()
                {
                    itemName = "Chicken",
                    itemPrice = 5
                };
                storeItem.StoreItemInventory = storeItemInventory;
                storeItem.StoreLocation = storeLocation;
                db4.StoreItemInventories.Add(storeItemInventory);
                db4.StoreLocations.Add(storeLocation);
                db4.StoreItems.Add(storeItem);
                db4.SaveChanges();

                if (inputQuantity <= db4.StoreItems.Include(x => x.StoreItemInventory)
                 .Where(x => x.StoreItemId == inputItem).First()
                 .StoreItemInventory.itemInventory) trueFalse = true; // checks if the inputted quantity is below store inventory
            }

            //Assert
            using (var db4 = new AppDbContext(options))
            {
                Assert.True(trueFalse);
            }
        }
        /// <summary>
        /// tests if database will update its item inventory
        /// </summary>
        [Fact]
        public void UpdatingInventoryQuantity()
        {
            //Test1
            //Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Test8")
                .Options;
            int inputQuantity = 4;
            int inputItem = 1;
            int itemQuantity = 0;


            //Act
            using (var db5 = new AppDbContext(options))
            {
                StoreLocation storeLocation = new StoreLocation()
                {
                    Location = "Houston"
                };
                StoreItemInventory storeItemInventory = new StoreItemInventory()
                {
                    itemInventory = 10
                };
                StoreItem storeItem = new StoreItem()
                {
                    itemName = "Chicken",
                    itemPrice = 5
                };
                storeItem.StoreItemInventory = storeItemInventory;
                storeItem.StoreLocation = storeLocation;
                db5.StoreItemInventories.Add(storeItemInventory);
                db5.StoreLocations.Add(storeLocation);
                db5.StoreItems.Add(storeItem);
                db5.SaveChanges();

                itemQuantity = db5.StoreItems.Include(x => x.StoreItemInventory)//stores the inventory quantity
                    .Where(x => x.StoreItemId == inputItem).First()
                    .StoreItemInventory.itemInventory;
                itemQuantity = itemQuantity - inputQuantity; //updates the inventory quantity
            }

            //Assert
            using (var db5 = new AppDbContext(options))
            {
                Assert.Equal(6, itemQuantity);
            }
        }
        /// <summary>
        /// test checks to make sure if user selects an entity that does not exists, 
        /// it throws an exception
        /// </summary>
        [Fact]
        public void InputValidationForUsers()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Test9")
                .Options;
            int inputId1 = 2;
            int inputId2 = 4;
            bool trueFalse = true;

            //Act
            using (var db7 = new AppDbContext(options))
            {
                UserInfo newUser = new UserInfo()
                {
                    fName = "David",
                    lName = "Leblanc",
                    userName = "Davidl",
                    password = "abc123"
                };
                UserInfo newUser1 = new UserInfo()
                {
                    fName = "James",
                    lName = "Jones",
                    userName = "jamesj",
                    password = "abc123"
                };

                db7.Add(newUser);
                db7.Add(newUser1);
                db7.SaveChanges();

                try
                {
                    db7.UserInfos.ToList().First(x => x.UserInfoId == inputId2);//check if user exists
                }
                catch
                {
                    trueFalse = false;
                }

            }
            //Assert
            using (var db7 = new AppDbContext(options))
            {
                Assert.Equal("James", db7.UserInfos.ToList().Find(x => x.UserInfoId == inputId1).fName);//matches user to id
                Assert.False(trueFalse);
            }
        }
        /// <summary>
        /// Tests to check user enters the Id displayed on the console screen.
        /// </summary>
        [Fact]
        public void InputValidationToCheckDisplayItemSelected()
        {

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Test10")
                .Options;
            int inputItem = 2;
            int inputItem1 = 9;
            int inputLocation = 1;
            bool trueFalse = true;
            bool trueFalse1 = true;


            //Act
            using (var db8 = new AppDbContext(options))
            {
                StoreLocation storeLocation = new StoreLocation()
                {
                    Location = "Houston"
                };
                StoreItem storeItem = new StoreItem()
                {
                    itemName = "Chicken",
                    itemPrice = 5
                };
                StoreItem storeItem1 = new StoreItem()
                {
                    itemName = "Pork",
                    itemPrice = 5
                };
                StoreItem storeItem2 = new StoreItem()
                {
                    itemName = "Beef",
                    itemPrice = 5
                };
                StoreItem storeItem3 = new StoreItem()
                {
                    itemName = "Fish",
                    itemPrice = 5
                };
                StoreItem storeItem4 = new StoreItem()
                {
                    itemName = "Veggies",
                    itemPrice = 5
                };
                storeItem.StoreLocation = storeLocation;
                storeItem1.StoreLocation = storeLocation;
                storeItem2.StoreLocation = storeLocation;
                storeItem3.StoreLocation = storeLocation;
                storeItem4.StoreLocation = storeLocation;

                db8.StoreLocations.Add(storeLocation);
                db8.StoreItems.Add(storeItem);
                db8.StoreItems.Add(storeItem1);
                db8.StoreItems.Add(storeItem2);
                db8.StoreItems.Add(storeItem3);
                db8.StoreItems.Add(storeItem4);

                db8.SaveChanges();
                try
                {
                    db8.StoreItems.Include(x => x.StoreLocation).Where(x => x.StoreLocation.StoreLocationId == inputLocation)
                        .First(x => x.StoreItemId == inputItem1); //check to access a certain item from a certain location
                }
                catch
                {
                    trueFalse = false;
                }
                try
                {
                    db8.StoreItems.Include(x => x.StoreLocation).Where(x => x.StoreLocation.StoreLocationId == inputLocation)
                        .First(x => x.StoreItemId == inputItem); //check if exception handling works
                }
                catch
                {
                    trueFalse1 = false;
                }

            }
            //Assert
            using (var db8 = new AppDbContext(options))
            {
                Assert.False(trueFalse);
                Assert.True(trueFalse1);
            }
        }

        [Fact]
        public void testingAdd()
        {
            var x = new Calculator();
            var y = x.Add(1, 2);
            Assert.Equal(3, y);
        }

    }
}
