using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallengeWeek3
{
    class Menu
    {
        internal void Run()
        {
            Console.Clear();
            Console.WriteLine("\n**************************************************");
            Console.WriteLine("\nWelcome to week 2 Coding challenge!!\n");
            Console.WriteLine("1. Is the Number Even??\n");
            Console.WriteLine("2. Multiplication Table\n");
            Console.WriteLine("3. Alternating Elements\n");
            Console.WriteLine("4. Ain't nobody got time for that!\n");
            Console.WriteLine("**************************************************\n");

            Console.WriteLine("Please select a number from above:\n");

            if ((int.TryParse(Console.ReadLine(), out int enteredChoice))
                && enteredChoice < 5 && enteredChoice > 0) //if statement to makesure user enters valid number
            {
                MainMethods test = new MainMethods(); //loads all the methods
                switch (enteredChoice) //switch statement to match what user inputted
                {
                    case 1:
                        {
                            test.IsEven(); //runs the IsEven method
                            break;
                        }
                    case 2:
                        {
                            test.MultTable(); //runs the MultTable method
                            break;
                        }
                    case 3:
                        {
                            test.Shuffle(); //runs the Shuffle method
                            break;
                        }
                    case 4:
                        {
                            Environment.Exit(0); //exits the console
                            break;
                        }
                }
            }
            else
            {
                Console.WriteLine("Come on... Select a number between 1 ~ 4.\n Enter to try one more time");
                Console.ReadLine();
                Run(); //re-runs the menu
            }

        }
    }
}
