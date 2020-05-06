using Project0.Properties;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Project0.NavigationFunc
{
    /// <summary>
    /// displays all user that can be selected to list their order histories
    /// implements IOrderHistory
    /// </summary>
    class DisplayAllUser : IOrderHistory
    {
        bool checking = true; //used for while loop
        bool checking1 = true;
        int selectedOrderId = 0;
        int selectedUserId = 0;
        public void OrderHistory()
        {
            using (var db = new AppDbContext())
            {
                while (checking1)
                { //while loop for user to check other user's orders
                    Console.Clear();
                    var listOfUsers = db.UserInfos; //store userinfos into listOfUsers
                    Console.WriteLine("\n**************************************************\n");
                    Console.WriteLine("Id\t\tUsername\n");
                    foreach (var user in listOfUsers) //display all user on console
                    {
                        Console.WriteLine($"{user.UserInfoId}\t\t{user.userName}");
                    }
                    Console.WriteLine("\n**************************************************");
                    Console.WriteLine("\nSelect the username Id to view their order histories");
                    try
                    {
                        selectedUserId = int.Parse(Console.ReadLine());
                        db.UserInfos.First(x => x.UserInfoId == selectedUserId); //input validation to check if entered ID exists in database
                    }
                    catch (FormatException) //format exception to catch if input is not int
                    {
                        Console.WriteLine("Please enter a NUMBER, enter to continue:");
                        Console.ReadLine();
                        continue; //returns to 'checking1' while loop
                    }
                    catch (InvalidOperationException)//invalid exception to catch if the input does not exist
                    {
                        Console.WriteLine("Please enter a valid Id, enter to continue:");
                        Console.ReadLine();
                        continue; //returns to 'checking1' while loop
                    }
                    catch (Exception e) //any other exception caught, displays the exception error.
                    {
                        Console.WriteLine(e);
                        Console.WriteLine("Please enter a valid Id, enter to continue:");
                        Console.ReadLine();
                        continue; //returns to 'checking1' while loop
                    }
                    var userOrder = db.UserOrders.Include(x => x.StoreLocation)
                        .Where(x => x.UserInfo.UserInfoId == selectedUserId); //stores selected user order.
                    while (checking) //while loop for user to check other orders of a user
                    {
                        Console.Clear();
                        Console.WriteLine("\n**************************************************\n");
                        Console.WriteLine("Order Id\tOrder Time\t\tLocation\n");
                        foreach (var x in userOrder) //foreach to display all user orders
                        {
                            Console.WriteLine($"   {x.UserOrderId}\t\t{x.timeStamp}\t{x.StoreLocation.Location}");
                        }
                        Console.WriteLine("\n**************************************************");
                        Console.WriteLine("\nSelect the order Id to view its details");
                        try //input validation to make sure entered ID exists in database
                        {
                            selectedOrderId = int.Parse(Console.ReadLine());
                            db.UserOrders.Include(x => x.UserInfo).Where(x => x.UserInfo.UserInfoId == selectedUserId)
                                .First(x => x.UserOrderId == selectedOrderId);
                        }
                        catch (FormatException) //format exception to catch if input is not int
                        {
                            Console.WriteLine("Please enter a NUMBER, enter to continue:");
                            Console.ReadLine();
                            continue; //returns to 'checking1' while loop
                        }
                        catch (InvalidOperationException)//invalid exception to catch if the input does not exist
                        {
                            Console.WriteLine("Please enter a valid Id, enter to continue:");
                            Console.ReadLine();
                            continue; //returns to 'checking1' while loop
                        }
                        catch (Exception e) //any other exception caught, displays the exception error.
                        {
                            Console.WriteLine(e);
                            Console.WriteLine("Please enter a valid Id, enter to continue:");
                            Console.ReadLine();
                            continue; //returns to 'checking1' while loop
                        }
                        var userOrder1 = db.UserOrders.Where(x => x.UserOrderId == selectedOrderId) //store table for Userorder, userquant, and storeitem infos
                                    .Include(x => x.UserOrderQuantity)
                                    .Include(x => x.UserOrderItems)
                                    .ThenInclude(x => x.StoreItem);
                        Console.Clear();
                        Console.WriteLine("\n**************************************************\n");
                        Console.WriteLine("Pet Name\t\t\tQuantity\n");
                        foreach (var x in userOrder1) //foreach to display item name and quantity ordered
                        {
                            var test = x.UserOrderItems.Zip(x.UserOrderQuantity); //zip to combine the two list (credit to Jayson)
                            foreach (var i in test)
                            {
                                Console.WriteLine("{0,-20}{1,16}", i.First.StoreItem.itemName, i.Second.orderQuantity);
                            }
                        }
                        Console.WriteLine("\n**************************************************\n");
                        Console.WriteLine("Would you like to check a different order? Y/N");
                        string yesNo = Console.ReadLine();
                        if (yesNo == "Y" || yesNo == "y") //if statement to loop through 'checking' while loop.
                        {
                            continue;
                        }
                        else
                        {
                            checking = false; //stops the 'checking' while loop
                        }
                    }
                    Console.WriteLine("Would you like to check orders from different user? Y/N");
                    string yesNo1 = Console.ReadLine();
                    if (yesNo1 == "Y" || yesNo1 == "y") //if statement to return back to 'checking1' while loop.
                    {
                        checking = true; //validate the 'checking' while loop again
                        continue;
                    }
                    else
                    {
                        checking1 = false; //exits the main 'checking1' while loop
                        MainNavigation test7 = new MainNavigation();
                        test7.WhereToNavigation();
                    }
                }
            }
        }
    }
    /// <summary>
    /// searches user by first name and last name
    /// Implements IOrderHistory
    /// </summary>
    class SearchUser :IOrderHistory
    {
        bool checking = true; //used for while loop
        bool checking1 = true;
        UserInfo check;
        int selectedOrderId = 0;
        public void OrderHistory()
        {
            using (var db = new AppDbContext())
            {
                    while (checking1) 
                    {
                    Console.Clear();
                    Console.WriteLine("\n**************************************************\n");
                    Console.WriteLine("Please enter the first name of customer");
                    string fName = Console.ReadLine().ToLower();
                    Console.WriteLine("\nPlease enter the last name of customer");
                    string lName = Console.ReadLine().ToLower();
                    Console.WriteLine("\n**************************************************\n");
                    try
                    {
                        check = db.UserInfos.First(u => u.fName == fName && u.lName == lName); //checks if the user inputted name matches database
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Please enter a valid user name, enter to continue:"); //returns to 'chicking1' while loop if exceptions were caught
                        Console.ReadLine();
                        continue;
                    }
                    catch (Exception e) //any other exception, print on console and return to 'checking1' while loop
                    {
                        Console.WriteLine(e);
                        Console.WriteLine("Please enter a valid user name, enter to continue:"); //returns to 'chicking1' while loop if exceptions were caught
                        Console.ReadLine();
                        continue;
                    }
                    var userOrder = db.UserOrders.Include(x=>x.StoreLocation) //store user order with store location
                            .Where(x => x.UserInfo.UserInfoId == check.UserInfoId);
                    while (checking) //while loop to view other orders of the selected user
                    {
                        Console.Clear();
                        Console.WriteLine("\n**************************************************");
                        Console.WriteLine("\nOrder Id\tOrder Time\tLocation\n");
                        foreach (var x in userOrder) //displays all orders made by user
                        {
                            Console.WriteLine($"   {x.UserOrderId}\t\t{x.timeStamp}\t{x.StoreLocation.Location}");
                        }
                        Console.WriteLine("\n**************************************************\n");
                        Console.WriteLine("\nSelect the order Id to view its details");

                        try  //input validation to make sure entered order ID exists in database
                        {
                            selectedOrderId = int.Parse(Console.ReadLine());
                            db.UserOrders.Include(x => x.UserInfo).Where(x => x.UserInfo == check).First(x => x.UserOrderId == selectedOrderId);
                            //db.UserOrders.First(x => x.UserOrderId == selectedOrderId);
                        }
                        catch (FormatException) //format exception to catch if input is not int
                        {
                            Console.WriteLine("Please enter a NUMBER, enter to continue:");
                            Console.ReadLine();
                            continue; //returns to 'checking' while loop
                        }
                        catch (InvalidOperationException)//invalid exception to catch if the input does not exist
                        {
                            Console.WriteLine("Please enter a valid Id, enter to continue:");
                            Console.ReadLine();
                            continue; //returns to 'checking' while loop
                        }
                        catch (Exception e) //any other exception caught, displays the exception error.
                        {
                            Console.WriteLine(e);
                            Console.WriteLine("Please enter a valid Id, enter to continue:");
                            Console.ReadLine();
                            continue; //returns to 'checking1' while loop
                        }
                        var userOrder1 = db.UserOrders.Where(x => x.UserOrderId == selectedOrderId) //store table for Userorder, userquant, and storeitem infos
                                    .Include(x => x.UserOrderQuantity)
                                    .Include(x => x.UserOrderItems)
                                    .ThenInclude(x => x.StoreItem);
                        Console.Clear();
                        Console.WriteLine("\n**************************************************\n");
                        Console.WriteLine("Pet Name\t\t\tQuantity\n");
                        foreach (var x in userOrder1) //foreach to display item name and quantity ordered
                        {
                            var test = x.UserOrderItems.Zip(x.UserOrderQuantity);
                            foreach (var i in test)
                            {
                                Console.WriteLine("{0,-20}{1,16}", i.First.StoreItem.itemName, i.Second.orderQuantity);
                            }
                        }
                        Console.WriteLine("\n**************************************************\n");
                        Console.WriteLine("Would you like to check a different order? Y/N");
                        string yesNo = Console.ReadLine();
                        if (yesNo == "Y" || yesNo == "y") //if statement to return back to the beginning while statement.
                        {
                            continue;
                        }
                        else
                        {
                            checking = false; //exits the 'checking' while loop
                        }
                    }
                        Console.WriteLine("Would you like to check orders from different user? Y/N");
                        string yesNo1 = Console.ReadLine();
                    if (yesNo1 == "Y" || yesNo1 == "y") //if statement to return back to the beginning while statement.
                    {
                        checking = true;
                        continue;
                    }
                    else
                    {
                        checking1 = false; //exits the main 'checking1' while loop
                        MainNavigation test7 = new MainNavigation();
                        test7.WhereToNavigation();
                    }
                }
            }
        }
    }
    /// <summary>
    /// displays location, selected location displays all orders for that location
    /// </summary>
    class OrderHistoryByLocation : IOrderHistory
    {
        bool checking = true;
        bool checking1 = true;
        int selectedOrderId = 0;
        IQueryable<UserOrder> dbOrders;
        public void OrderHistory()
        {
            using (var db = new AppDbContext())
            {
                while (checking)
                {
                    Console.Clear();
                    Console.WriteLine("\n**************************************************\n");
                    var locations = db.StoreLocations; //stores Storelocation table names into locations list
                    foreach (var x in locations) //prints all shop locations onto the console
                    {
                        Console.WriteLine(x.StoreLocationId + "." + x.Location);
                    }
                    Console.WriteLine("\n**************************************************\n");
                    Console.WriteLine("Select a location to see all orders placed there");
                    int selectedLocation = 0;
                    if (int.TryParse(Console.ReadLine(), out selectedLocation)
                        && selectedLocation > 0 && selectedLocation < 6) //input validation to make sure user input is int
                    {
                        try //input validation to make sure input id matches database
                        {
                            dbOrders = db.UserOrders.Include(x => x.StoreLocation)
                                .Where(x => x.StoreLocation.StoreLocationId == selectedLocation); //stores user orders with store location included
                        }
                        catch (InvalidOperationException) //format exception to catch if input is not int
                        {
                            Console.WriteLine("Please enter a NUMBER, enter to continue:");
                            Console.ReadLine();
                            continue; //returns to 'checking1' while loop
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please enter to try again");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                    Console.Clear();
                    while (checking1)
                    {
                        Console.Clear();
                        Console.WriteLine("\n**************************************************\n");
                        Console.WriteLine("Order Id\t\tOrder Time\t\tLocation\n");
                        foreach (var x in dbOrders) //displays all user order for the selected location
                        {
                            Console.WriteLine($"{x.UserOrderId}\t\t{x.timeStamp}\t{x.StoreLocation.Location}");
                        }
                        Console.WriteLine("\n**************************************************");
                        Console.WriteLine("\nSelect the order Id to view its details");
                        try
                        {
                            selectedOrderId = int.Parse(Console.ReadLine());
                            db.UserOrders.Include(x=>x.StoreLocation).Where(x=>x.StoreLocation.StoreLocationId==selectedLocation)
                                .First(x => x.UserOrderId == selectedOrderId); //input validation for the selected order id
                        }
                        catch (FormatException) //format exception to catch if input is not int
                        {
                            Console.WriteLine("Please enter a NUMBER, enter to continue:");
                            Console.ReadLine();
                            continue; //returns to 'checking1' while loop
                        }
                        catch (InvalidOperationException)//invalid exception to catch if the input does not exist
                        {
                            Console.WriteLine("Please enter a valid Id, enter to continue:");
                            Console.ReadLine();
                            continue; //returns to 'checking1' while loop
                        }
                        catch (Exception e) //any other exception caught, displays the exception error.
                        {
                            Console.WriteLine(e);
                            Console.WriteLine("Please enter a valid Id, enter to continue:");
                            Console.ReadLine();
                            continue; //returns to 'checking1' while loop
                        }
                        var userOrder1 = db.UserOrders.Where(x => x.UserOrderId == selectedOrderId) //store table for Userorder, userquant, and storeitem infos
                                .Include(x => x.UserOrderQuantity)
                                .Include(x => x.UserOrderItems)
                                .ThenInclude(x => x.StoreItem);
                        var userOrdered = db.UserOrders.Include(x => x.UserInfo)
                            .First(x => x.UserOrderId == selectedOrderId).UserInfo;                       
                        Console.Clear();
                        Console.WriteLine("\n**************************************************\n");
                        Console.WriteLine($"Order by: {userOrdered.fName} {userOrdered.lName}\n");
                        Console.WriteLine("Pet Name\t\t\tQuantity\n");
                        foreach (var x in userOrder1)
                            {
                                var test = x.UserOrderItems.Zip(x.UserOrderQuantity);
                                foreach (var i in test) //foreach to display item name and quantity ordered
                            {
                                Console.WriteLine("{0,-20}{1,16}",i.First.StoreItem.itemName, i.Second.orderQuantity);//////////////////////////////////////////////////////
                                }
                            }
                        Console.WriteLine("\n**************************************************\n");
                        Console.WriteLine("Would you like to check a different order? Y/N");
                        string yesNo = Console.ReadLine();
                        if (yesNo == "Y" || yesNo == "y") //if statement to return back to 'checking1' while loop
                        {
                            continue;
                        }
                        else
                        {
                            checking1 = false; //exits the 'checking1' while loop
                        }
                    }
                    Console.WriteLine("Would you like to check a different location? Y/N");
                    string yesNo1 = Console.ReadLine();
                    if (yesNo1 == "Y" || yesNo1 == "y") //if statement to return back to the 'checking' while loop
                    {
                        checking = true;
                        checking1 = true;
                        continue;
                    }
                    else
                    {
                        checking = false;
                        MainNavigation test7 = new MainNavigation();
                        test7.WhereToNavigation();
                    }
                }
            }
        }
    }
}
