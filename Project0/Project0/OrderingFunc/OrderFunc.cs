﻿using System;
using Project0.Properties;
using Project0.RegiAndLoginFunc;
using Project0.NavigationFunc;
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
        StoreItem userPickedItem;
        int newInventory = 0;
        int enteredQuantity = 0;
        int userPickedItemInventory = 0;
        bool anotherBuy = true;
        bool loopConditionForQuantity = true;
        bool ifDoesntExist = true;
        DisplayLocations displayLocation = new DisplayLocations();

        public void StartOrder() //method to run UserLogin, DisplayFunc, and Ordering
        {
            DisplayFunc test2 = new DisplayFunc();
            test2.SeeStores();
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
                    Console.Clear();
                    displayLocation.ShowLocationItem();
                    Console.WriteLine("Please select the pet you would like to take home today!" +
                        "\nEnter pet number displayed next to the name to add to cart:");

                    try //this try will check if the entered id is a valid id within that selected location and if it is an integer
                    {
                        int purchaseId = int.Parse(Console.ReadLine()); //parse input to int
                        userPickedItem = db.StoreItems.Include(x => x.StoreLocation).Include(x=>x.StoreItemInventory)
                            .Where(x => x.StoreLocation.StoreLocationId == DisplayLocations.input1)
                            .First(x => x.StoreItemId == purchaseId); //stores the item selected, its location, its inventory into userPickedItem
                        userPickedItemInventory = userPickedItem.StoreItemInventory.itemInventory; //store the available inventory of the selected pet
                    }
                    catch(InvalidOperationException) //if any exceptions were caught, return to the start of the 'anotherBuy' while loop.
                    {
                        Console.WriteLine("The pet id you entered did not match any of the pets, Please enter to try again");
                        Console.ReadLine();
                        continue; //when exception is caught, 'continue' allows this program to start over from 'anotherbuy' while loop again
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine("Please enter a valid Id NUMBER, enter to try again");
                        Console.ReadLine();
                        continue; //when exception is caught, 'continue' allows this program to start over from 'anotherbuy' while loop again
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine("I don't know what you entered but please read, Please enter to try again");
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
                            Console.WriteLine("The entered amount exceeds or is " +
                                "not a valid input in our store inventory, please try again."); //restart the while loop because the conditional 'loopConditionForQuantity' is still true
                        }
                    }
                    var currentUser1 = db.UserInfos.ToList().Find(x => x.userName == UserLogin._userName); //stores current user info
                    var currentItem = db.StoreItems.ToList().Find(x => x.StoreItemId == userPickedItem.StoreItemId); //stores current item id
                    var currentLocation = db.StoreItems.Include(x => x.StoreLocation).ToList()
                        .Find(x => x.StoreItemId == userPickedItem.StoreItemId).StoreLocation; //stores current store location

                    if (ifDoesntExist) //if statement to create user order only once. once created bool value are assigned negative.
                    {
                        UserOrder userOrder = new UserOrder //create a new order
                        {
                            StoreLocation = currentLocation,
                            UserInfo = currentUser1, //store current user information
                            timeStamp = DateTime.Now //store time stamp of this new order
                        };
                        db.Add(userOrder); //add a user order entity to the database, this needs to be added first before the latter two due to FK restrictions
                        db.SaveChanges();
                        ifDoesntExist = false;
                    }
                    var currentUserOrder = db.UserOrders.ToList().Last(); //store the current order id
                    UserOrderItem userOrderItem = new UserOrderItem //create a new item order obj
                    {
                        StoreItem = currentItem,
                        UserOrder = currentUserOrder
                    };
                    db.Add(userOrderItem); //add a user order item entity to the database

                    UserOrderQuantity userOrderQuantity = new UserOrderQuantity //create a new user order quantity obj
                    {
                        UserOrder = currentUserOrder,
                        StoreItem = currentItem,
                        orderQuantity = enteredQuantity
                    };
                    db.Add(userOrderQuantity); //add a user order quantity entity to the database

                    var updateInventory = db.StoreItemInventories //selects the user chosen item inventory
                        .First(x => x.StoreItemInventoryId == userPickedItem.StoreItemInventory.StoreItemInventoryId);
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
                }
                MainNavigation test7 = new MainNavigation();
                test7.WhereToNavigation();
            }
        }
    }
}
