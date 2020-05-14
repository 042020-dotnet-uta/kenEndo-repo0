using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0.RegiAndLoginFunc
{
    /// <summary>
    /// class for userlogin authentication
    /// </summary>
    public class UserLogin
    {
        internal static string _userName; //stores the current user info
        private string _password;

        /// <summary>
        /// method checks if entered username exists
        /// </summary>
        public void runLogin()
        {
            AskInfo();   //runs the askinfo method
        using(var db = new AppDbContext())
            {
                try //this checks if the username and password matches anything in database
                {
                    db.UserInfos.First(u => u.userName == _userName && u.password == _password);
                    Console.WriteLine("Success!\n Press Enter to go to the store page");
                    Console.ReadLine();
                }
                catch(InvalidOperationException) //checks for invalid operation exception
                {
                    Console.WriteLine("Wrong username or password, please enter try again");
                    Console.ReadLine();
                    runLogin();
                }
                catch(Exception e) // checks for any other exceptions and display it
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Wrong username or password, please enter try again");
                    Console.ReadLine();
                    runLogin();
                }
            }
        }
        /// <summary>
        /// Method that asks user for its username and password
        /// </summary>
        public void AskInfo()
        {
            Console.Clear();
            Console.WriteLine("\n**************************************************\n");
            Console.WriteLine("\t\tUser Login");
            Console.WriteLine("\n**************************************************\n");
            Console.WriteLine("Please enter your username");
            _userName = Console.ReadLine(); //stores username info
            Console.WriteLine("\nPlease enter your password");
            _password = Console.ReadLine(); //stores password info
            Console.WriteLine("\n**************************************************\n");
        }
    }
}
