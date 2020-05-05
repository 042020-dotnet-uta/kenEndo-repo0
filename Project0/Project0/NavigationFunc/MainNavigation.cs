using System;
using System.Collections.Generic;
using System.Text;
using Project0.OrderingFunc;

namespace Project0.NavigationFunc
{
    /// <summary>
    /// main navigational class that user sees after logging in.
    /// user has options to select: check location to make orders,
    /// search user and see order history, display all user and select user to
    /// see their order history, display all location and check order history
    /// of that location.
    /// </summary>
    class MainNavigation
    {
        internal void WhereToNavigation()
        {
            Console.Clear();
            Console.WriteLine("\n**************************************************\n");
            Console.WriteLine("1.\tVisit the Stores\n");
            Console.WriteLine("2.\tSearch User and display order history\n");
            Console.WriteLine("3.\tDisplay all users and check order history\n");
            Console.WriteLine("4.\tDisplay all locations and check order history\n");
            Console.WriteLine("**************************************************\n");

            if((int.TryParse(Console.ReadLine(),out int selectedNavigation)) //input validation to check user input 
                && selectedNavigation > 0 && selectedNavigation < 5)
            {
                switch (selectedNavigation) //switch output for user selection
                {
                    case 1:
                        {
                            OrderFunc test3 = new OrderFunc(); //directs user to store location page
                            test3.StartOrder();
                            break;
                        }
                    case 2:
                        {
                            SearchUser test5 = new SearchUser(); //directs user search user page
                            test5.OrderHistory();
                            break;
                        }
                    case 3:
                        {
                            DisplayAllUser test4 = new DisplayAllUser(); // directs user to display all user page
                            test4.OrderHistory();
                            break;
                        }
                    case 4:
                        {
                            OrderHistoryByLocation test6 = new OrderHistoryByLocation(); // directs user to display all location page
                            test6.OrderHistory();
                            break;
                        }
                }
            }
            else //if input invalid, repeat the methods
            {
                Console.WriteLine("Please enter a valid number between 1 and 4, enter to try again");
                Console.ReadLine();
                WhereToNavigation();
            }
        }
    }
}
