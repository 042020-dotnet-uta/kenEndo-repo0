using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0
{
    public class UserLogin
    {
        private string _userName;
        private string _password;
        public void runLogin()
        {
            askInfo();
            //need to make code to compare inputted username/password with the registered user info in the database.
        
        using(var db = new AppDbContext())
            {
                try
                {
                    var check = db.UserInfos.First(u => u.userName == _userName && u.password == _password);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Wrong username or password, please try again");
                    Console.Clear();
                    runLogin();
                }                
            }
            Console.WriteLine("Success!\n Press Enter to go to the store page");
            Console.ReadLine();
            Console.Clear();
            //direct user to the store location page where user picks location.
        }


        public void askInfo()
        {
            Console.WriteLine("Please enter your username");
            _userName = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            _password = Console.ReadLine();
        }
    }
}
