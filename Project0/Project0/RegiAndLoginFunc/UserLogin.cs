using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0.RegiAndLoginFunc
{
    public class UserLogin
    {
        private string _userName;

        public string userName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        UserInfo check;

        private string _password;
        public UserInfo runLogin()
        {
            askInfo();
            //need to make code to compare inputted username/password with the registered user info in the database.
        
        using(var db = new AppDbContext())
            {
                try
                {
                    check = db.UserInfos.First(u => u.userName == _userName && u.password == _password);
                    Console.WriteLine("Success!\n Press Enter to go to the store page");
                    Console.ReadLine();
                    Console.Clear();
                    return check;
                }
                catch(Exception e)
                {
                    Console.WriteLine("Wrong username or password, please enter try again");
                    Console.ReadLine();
                    Console.Clear();
                    return runLogin();
                }                
            }
            //direct user to the store location page where user picks location.
        }


        public void askInfo()
        {
            Console.WriteLine("Please enter your username");
            userName = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            _password = Console.ReadLine();
        }
    }
}
