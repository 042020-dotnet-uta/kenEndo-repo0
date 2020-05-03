﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Project0.RegiAndLoginFunc
{
    public class UserRegistration
    {

        public void runRegistration()
        {
            Console.Clear();
            Console.WriteLine("\nPlease enter your first name");
            string fname = Console.ReadLine();
            Console.WriteLine("\nPlease enter your last name");
            string lname = Console.ReadLine();
            Console.WriteLine("\nPlease register your username");
            string userName = Console.ReadLine();
            Console.WriteLine("\nPlease enter your new password");
            string password = Console.ReadLine();
            Console.WriteLine("\nPlease re-enter your new password to confirm");
            string password2 = Console.ReadLine();
            if (password == password2)
            {
                Console.Clear();
                Console.WriteLine("\n**************************************************\n");
                Console.WriteLine($"First Name: \t{fname}");
                Console.WriteLine($"Last Name: \t{lname}");
                Console.WriteLine($"Username: \t{userName}");
                Console.WriteLine($"Password: \t{password2}");
                Console.WriteLine("\n**************************************************\n");
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
                    try
                    {
                        using (var db = new AppDbContext())
                        {
                            db.Add(user);
                            db.SaveChanges();
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.InnerException.ToString());
                    }
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