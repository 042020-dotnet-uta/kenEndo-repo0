using System;
using System.Collections.Generic;
using Project0.Properties;
using Project0.RegiAndLoginFunc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Project0.OrderingFunc
{
    /// <summary>
    /// Class in charge of running the main functionality. Instantiates class for user login.
    /// Displays location of stores for user to select.
    /// Displays items available at the store user selected.
    /// Allow user to make multiple order at the selected store.
    /// </summary>
    class OrderFunc
    {
        UserInfo currentUser;
        StoreItem userPickedItem;
        List<StoreItem> currentStore;
        int newInventory = 0;
        int enteredQuantity = 0;
        int userPickedItemInventory = 0;
        bool anotherBuy = true;
        bool loopConditionForQuantity = true;
        bool ifDoesntExist = true;

        public void StartOrder() //method to run UserLogin, DisplayFunc, and Ordering
        {
            UserLogin test1 = new UserLogin();
            currentUser = test1.runLogin();
            DisplayFunc test2 = new DisplayFunc();
            currentStore = test2.SeeStores();
            ordering();
        }
        /// <summary>
        /// Method used to fill database with single or multiple order from a selected location
        /// </summary>
        void ordering()
        {
            using (var db = new AppDbContext())
            {
                while (anotherBuy) //this while loop is used for user that wants to make multiple order
                {
                    try //this try will check if the user selected item id matches the pet id displayed
                    {
                        Console.WriteLine("Please select the pet you would like to take home today!" +
                            "\nEnter pet number displayed next to the name to add to cart:");

                        int purchaseId = int.Parse(Console.ReadLine());//if statment to check if the user entered number is an existing item id

                        userPickedItem = db.StoreItems.Where(x => x.StoreItemId == purchaseId) //store the user selected pet id, this will throw an exception if user input does not match database
                             .Include(y => y.StoreItemInventory).ToList().First();

                        userPickedItemInventory = userPickedItem.StoreItemInventory.itemInventory; //store the available inventory of the selected pet
                    }
                    catch //if any exceptions were caught, return to the start of the 'anotherBuy' while loop.
                    {
                        Console.WriteLine("The pet id you entered did not match any of the pets, Please enter to try again");
                        Console.ReadLine();
                        continue; //when exception is caught, 'continue' allows this program to start over from 'anotherbuy' while loop again
                    }
                    while (loopConditionForQuantity) //while loop for input validation on quantity of pet selected, will loop as long as user enter wrong quantity
                    {
                        Console.WriteLine($"How many would you like to take home?");
                        if (int.TryParse(Console.ReadLine(), out enteredQuantity)
                            && enteredQuantity <= userPickedItemInventory
                            && enteredQuantity > 0) //check if user entered quantity is a number, below the store inventory, and above 0
                        {
                            newInventory = userPickedItemInventory - enteredQuantity; //store the updated inventory of pet after purchase
                            loopConditionForQuantity = false; //leave the input validation loop
                        }
                        else
                        {
                            Console.WriteLine("The entered amount exceeds our store inventory, please try again."); //restart the while loop because the conditional 'loopConditionForQuantity' is still true
                        }
                    }
                    var currentUser1 = db.UserInfos.ToList().Find(x => x.UserInfoId == currentUser.UserInfoId); //store the current user information

                    if (ifDoesntExist) //if statement to create user order only once. once created bool value are assigned negative.
                    {
                        UserOrder userOrder = new UserOrder //create a new order
                        {
                            UserInfo = currentUser1, //store current user information
                            timeStamp = DateTime.Now //store time stamp of this new order
                        };
                        db.Add(userOrder); //add a user order entity to the database, this needs to be added first before the latter two due to FK restrictions
                        db.SaveChanges();
                        ifDoesntExist = false;
                    }
                    var currentUserOrder = db.UserOrders.ToList().Last(); //store the current order id
                    var currentStore1 = db.StoreItems.ToList().Find(x => x.StoreItemId == userPickedItem.StoreItemId); //store the current item id
                    UserOrderItem userOrderItem = new UserOrderItem //create a new item order obj
                    {
                        StoreItem = currentStore1,
                        UserOrder = currentUserOrder
                    };
                    db.Add(userOrderItem); //add a user order item entity to the database

                    UserOrderQuantity userOrderQuantity = new UserOrderQuantity //create a new user order quantity obj
                    {
                        UserOrder = currentUserOrder,
                        StoreItem = currentStore1,
                        orderQuantity = enteredQuantity
                    };
                    db.Add(userOrderQuantity); //add a user order quantity entity to the database
                    var updateInventory = db.StoreItemInventories.First(x => x.StoreItemInventoryId == userPickedItem.StoreItemInventory.StoreItemInventoryId);
                    updateInventory.itemInventory = newInventory; //update the new store inventory of pet in database
                    db.SaveChanges();

                    Console.WriteLine("Would you like to bring home another pet? Please select Y/N");
                    string yesNo = Console.ReadLine();
                    if (yesNo == "Y" || yesNo == "y") //if statement to return back to the beginning while statement.
                    {
                        loopConditionForQuantity = true; //allow console to prompt for item quantity again
                        continue;
                    }
                    else
                    {
                        anotherBuy = false; //exits the main 'anotherBuy' while loop
                    }
                    Console.WriteLine("end of program");
                }
            }
        }
    }
}
