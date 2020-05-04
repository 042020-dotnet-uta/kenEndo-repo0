using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace CodingChallengeWeek3
{
    class MainMethods
    {
        /// <summary>
        /// Method to check if user entered value is an even or odd number
        /// </summary>
        internal void IsEven()
        {
            Console.Clear();
            Console.WriteLine("Please enter a number to check if its even");
            string entered = Console.ReadLine();
            string finalType;
            if (!string.IsNullOrWhiteSpace(entered)) //input validation for spaces and enters
            {
                int tryInt;
                decimal tryDec;
                if (Int32.TryParse(entered, out tryInt)) //input validation for integer
                {
                    finalType = "Integer";
                    if (tryInt % 2 == 0) //check if input is an even number
                    {
                        Console.WriteLine($"The entered number is an Even {finalType}");
                    }
                    else
                    {
                        Console.WriteLine($"The entered number is an Odd {finalType}");
                    }
                }
                else if (Decimal.TryParse(entered, out tryDec)) //input validation for decimal
                {
                    finalType = "Decimal";
                    Console.WriteLine($"The entered number is {finalType}");
                }
                else //input validation for string
                {
                    finalType = "String";
                    Console.WriteLine($"'{entered}' is a {finalType}, Please enter a number");
                }
            }
            else
            {
                Console.WriteLine("Please enter a value");
            }
            returnToMenu(); //method to return user to menu screen
        }
        /// <summary>
        /// Method to display user input as a multiplication table
        /// </summary>
        internal void MultTable()
        {
            Console.Clear();
            Console.WriteLine("Please enter a number to create a multiplication table\n");
            string entered = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(entered)) //input validation for spaces and enters
            {
                if (int.TryParse(entered, out int enteredNumber)) //input validation for a number
                {
                    for (int i = 1; i <= enteredNumber; i++) //creation of multiplication table, controls the left side of the multiplication
                    {
                        for (int x = 1; x <= enteredNumber; x++) // controls the right side of the multiplication table
                        {
                            Console.Write($"{i} x {x} = {i * x}, ");
                        }
                        Console.WriteLine("");
                    }
                }
                else
                {
                    Console.WriteLine($"{entered} is not a number, Please try again and enter a number");
                    Console.ReadLine();
                    Console.Clear();
                    MultTable();
                }
            }
            returnToMenu(); //method to return user to menu screen
        }
        /// <summary>
        /// Method to store two list of five element list from user and combine with alternating order
        /// </summary>
        internal void Shuffle()
        {
            Console.Clear();
            List<Object> firstList = new List<object>(); //two lists user will create
            List<Object> secondList = new List<object>();

            Console.WriteLine("Please enter 5 values to create the first list");
            for (int i = 1; i < 6; i++) //this forloop will ask user for the element and add to list
            {
                Console.WriteLine($"Please enter element # {i} for the first list");
                var entered = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(entered)) //input validation on empty or space input
                {
                    firstList.Add(entered);
                }
                else
                {
                    Console.WriteLine("please enter something, entery to try again.");
                    Console.ReadLine();
                    i -= 1; //if user entered an invalid element, it will return an iteration and ask again
                }
            }
            Console.Clear();
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine($"Please enter element # {i} for the first list");
                var entered = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(entered)) //input validation on empty or space input
                {
                    secondList.Add(entered);
                }
                else
                {
                    Console.WriteLine("please enter something, entery to try again.");
                    Console.ReadLine();
                    i -= 1; //if user entered an invalid element, it will return an iteration and ask again
                }
            }

            var newList = combineList(firstList, secondList); //using the combineList method(scroll down) to combine two list 
            Console.Clear();
            Console.Write("\n[" + string.Format(string.Join(", ", newList)) + "]"); //display on console in a line
            returnToMenu(); //returns user to the main menu

            List<Object> combineList(List<Object> first, List<Object> second) //argument method that combines two list into one.
            {
                List<Object> newList = new List<object>();
                for (int i = 0; i < 5; i++) //combines two list using for loop into newList
                {
                    newList.Add(first[i]);
                    newList.Add(second[i]);
                }
                return newList;
            }
        }

        internal void returnToMenu() //method to return user back to the menu screen
        {
            Console.WriteLine("\n\nEnter to return to the main menu");
            Console.ReadLine();
            Menu codeChallengeW2 = new Menu();
            codeChallengeW2.Run();
        }
    }
}
