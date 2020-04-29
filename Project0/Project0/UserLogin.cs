using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    public class UserLogin
    {
        private string userName;
        private string password;
        public void runLogin()
        {
            askInfo();
            //need to make code to compare inputted username/password with the registered user info in the database.
        }


        public void askInfo()
        {
            Console.WriteLine("Please enter your username");
            userName = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            password = Console.ReadLine();
        }
    }
}
