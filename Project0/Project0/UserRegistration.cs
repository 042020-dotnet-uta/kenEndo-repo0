using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    public class UserRegistration
    {

        public void runRegistration()
        {
            Console.WriteLine("Please enter your first name");
            string fname = Console.ReadLine();
            Console.WriteLine("Please enter your last name");
            string lname = Console.ReadLine();
            Console.WriteLine("Please register your username");
            string userName = Console.ReadLine();
            Console.WriteLine("Please enter your new password");
            string password = Console.ReadLine();
            Console.WriteLine("Please re-enter your new password to confirm");
            string password2 = Console.ReadLine();
            if (password == password2)
            {
                Console.Clear();
                Console.WriteLine("**************************************************");
                Console.WriteLine($"First Name: {fname}");
                Console.WriteLine($"Last Name: {lname}");
                Console.WriteLine($"Username: {userName}");
                Console.WriteLine($"Password: {password2}");
                Console.WriteLine("**************************************************");
                Console.WriteLine("If above informations are correct please enter 'Y' if not please enter 'N'");
                string yesNo = Console.ReadLine();
                if (yesNo == "Y" || yesNo == "y")
                {
                    Console.WriteLine("**************************************************");
                    UserInfo user = new UserInfo(fname, lname, userName, password2);
                    Console.WriteLine("Your account has been successfully created!");
                    Console.WriteLine("Press any button to be directed to the login page");
                    Console.ReadLine();
                    Console.Clear();
                    //need a function here to add this user class to the database
                }
                else
                {
                    Console.WriteLine("Please enter to start over");
                    Console.ReadLine();
                    Console.Clear();
                    runRegistration();
                }
            }
            else
            {
                Console.WriteLine("Password did not match, please enter to start over");
                Console.ReadLine();
                Console.Clear();
                runRegistration();
            }
        }

    }
}
