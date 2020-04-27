using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{

    class UserRegistration
    {
        internal void runRegistration()
        {
            Console.WriteLine("Please enter your full name");//need to add more condition
            string name = Console.ReadLine();
            Console.WriteLine("Please register your username");//need to add more condition
            string userName = Console.ReadLine();
            Console.WriteLine("Please enter your new password");
            string password = Console.ReadLine();
            Console.WriteLine("Please re-enter your new password to confirm");
            string password2 = Console.ReadLine();
            if(password == password2)
            {
                Console.WriteLine("Please enter your 10 digit phone #(do not include '-' nor spaces)");
                string phone = Console.ReadLine();
                if(phone.Length==10&&long.TryParse(phone,out long x)){//need to add more condition
                    Console.Clear();
                    Console.WriteLine("**************************************************");
                    Console.WriteLine($"Your name is: {name}");
                    Console.WriteLine($"Your user name is: {userName}");
                    Console.WriteLine($"Your password is: {password2}");
                    Console.WriteLine($"Your phone number is: {phone}");
                    Console.WriteLine("**************************************************");
                    Console.WriteLine("If above informations are correct please enter 'Y' if not please enter 'N'");
                    string yesNo = Console.ReadLine();
                    if (yesNo == "Y"||yesNo=="y")
                    {
                        Console.WriteLine("**************************************************");
                        UserInfo user = new UserInfo(name, userName, password2, phone);
                        Console.WriteLine("Your account has been successfully created!");
                        Console.WriteLine("Press any button to be directed to the login page");
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("testing");
                        Console.WriteLine(user.name);
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
                    Console.WriteLine("Phone number in the wrong format, please enter to start over");
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
        internal void loginPage()
        {

        }
    }
}
