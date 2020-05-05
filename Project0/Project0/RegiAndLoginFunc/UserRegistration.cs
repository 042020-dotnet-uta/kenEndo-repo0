using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Project0.RegiAndLoginFunc
{/// <summary>
/// Class for user to register their information and insert into database
/// </summary>
    public class UserRegistration
    {
        public void runRegistration()
        {
            Console.Clear();
            Console.WriteLine("\nPlease enter your first name"); 
            string fname = Console.ReadLine(); //stores first name
            Console.WriteLine("\nPlease enter your last name");
            string lname = Console.ReadLine(); //stores last name
            Console.WriteLine("\nPlease register your username");
            string userName = Console.ReadLine(); //stores username
            Console.WriteLine("\nPlease enter your new password");
            string password = Console.ReadLine(); //stores password
            Console.WriteLine("\nPlease re-enter your new password to confirm");
            string password2 = Console.ReadLine(); //stores confirmation password
            if (password == password2) //check if the two password matches
            {
                Console.Clear();
                Console.WriteLine("\n**************************************************\n");
                Console.WriteLine($"First Name: \t{fname}"); //displays user infos
                Console.WriteLine($"Last Name: \t{lname}");
                Console.WriteLine($"Username: \t{userName}");
                Console.WriteLine($"Password: \t{password2}");
                Console.WriteLine("\n**************************************************\n");
                Console.WriteLine("If above informations are correct please enter 'Y' if not please enter 'N'");
                string yesNo = Console.ReadLine();
                if (yesNo == "Y" || yesNo == "y") //confirmation to check if all user information is correct
                {
                    Console.WriteLine("**************************************************");
                    UserInfo user = new UserInfo(fname, lname, userName, password2);
                    Console.WriteLine("Your account has been successfully created!");
                    Console.WriteLine("Press any button to be directed to the login page");
                    Console.ReadLine();
                    Console.Clear();
                    using (var db = new AppDbContext())
                    {
                        db.Add(user); // adds the new userinfo into the database
                        db.SaveChanges();
                    }
                }
                else // if user do not enter 'y'
                {
                    Console.WriteLine("Please enter to start over");
                    Console.ReadLine();
                    runRegistration();
                }
            }
            else // if password does not match, start over.
            {
                Console.WriteLine("Password did not match, please enter to start over");
                Console.ReadLine();
                runRegistration();
            }
        }

    }
}
