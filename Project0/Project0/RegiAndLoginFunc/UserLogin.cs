using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0.RegiAndLoginFunc
{
    public class UserLogin
    {
        internal static string _userName;
        UserInfo check;
        private string _password;
        public void runLogin()
        {
            askInfo();   
        using(var db = new AppDbContext())
            {
                try
                {
                    check = db.UserInfos.First(u => u.userName == _userName && u.password == _password);
                    Console.WriteLine("Success!\n Press Enter to go to the store page");
                    Console.ReadLine();
                    Console.Clear();
                }
                catch(Exception e)
                {
                    Console.WriteLine("Wrong username or password, please enter try again");
                    Console.ReadLine();
                    Console.Clear();
                    runLogin();
                }                
            }
        }
        public void askInfo()
        {
            Console.Clear();
            Console.WriteLine("\n**************************************************\n");
            Console.WriteLine("\t\tUser Login");
            Console.WriteLine("\n**************************************************\n");
            Console.WriteLine("Please enter your username");
            _userName = Console.ReadLine();
            Console.WriteLine("\nPlease enter your password");
            _password = Console.ReadLine();
            Console.WriteLine("\n**************************************************\n");
        }
    }
}
