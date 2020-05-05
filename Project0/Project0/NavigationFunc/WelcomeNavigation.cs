using System;
using System.Collections.Generic;
using System.Text;
using Project0.RegiAndLoginFunc;

namespace Project0.NavigationFunc
{
    /// <summary>
    /// a welcome class that displays user option to 
    /// either register or login to the store page
    /// </summary>
    class WelcomeNavigation
    {
        internal void Welcome()
        {
            Console.Clear();
            Console.WriteLine("\n**************************************************************\n");
            Console.WriteLine("\t\t    The Tiger King Pet Shop");
            Console.WriteLine("\n**************************************************************\n");
            Console.WriteLine("Welcome to the console app for Tiger King Pet Shop!" +
                "\nWe sell anything from fish, dogs, cats to exotic reptiles!!" +
                "\nATTENTION: We not longer sell tigers due to pending law suits from \nBig Cat Rescue");
            Console.WriteLine("\nPlease select one of the options below:");
            Console.WriteLine("1. Login\n2. Create a new user account");
            if((int.TryParse(Console.ReadLine(),out int userSelection)) //input validation to check if selection is int and between 0~3
                && userSelection <3 && userSelection > 0)
            {
                switch (userSelection) //switch output for user selection
                {
                    case 1:
                        {
                            UserLogin test1 = new UserLogin(); //directs user to login page
                            test1.runLogin();
                            MainNavigation test7 = new MainNavigation(); //directs user back to this navigation page
                            test7.WhereToNavigation();
                            break;
                        }
                    case 2:
                        {
                            UserRegistration test = new UserRegistration(); //directs user to registration page
                            test.runRegistration();
                            UserLogin test1 = new UserLogin(); //directs user to login page after registration
                            test1.runLogin();
                            MainNavigation test7 = new MainNavigation(); //directs user back to this navigation page
                            test7.WhereToNavigation();
                            break;
                        }
                }
            }
            else //if input is invalid, repeats this Welcome method.
            {
                Console.WriteLine("Please enter a valid number between 1 and 2, enter to try again");
                Console.ReadLine();
                Welcome();
            }
        }
    }
}
