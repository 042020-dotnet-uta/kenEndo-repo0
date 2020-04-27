using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge
{
    class Week1
    {
        int ss = 0; //total sweet and salty count 
        int sw = 0; //total sweet count
        int sl = 0; //total salty count

        public void toHundred() 
        {
            for (int i = 1; i <= 100; i++) // for loop to display the number 1 to 100
            {
                if (i % 3 == 0 && i % 5 == 0) // if statement to display "sweet'nsalty" instead of the number divisible by 3 or 5
                {
                    ss++; // adds 1 to the total count of sweet'nsalty
                    Console.WriteLine("sweet'nSalty");
                }else if (i % 3 == 0) // if statement to display "sweet" instead of the number divisible by 3
                {
                    sw++; //adds 1 to the total count of sweet
                    Console.WriteLine("sweet");
                }else if (i % 5 == 0) //if statement to display "salty" instead of the number divisible 5
                {
                    sl++; //adds 1 to the total count of salty
                    Console.WriteLine("salty");
                }
                else
                {
                    Console.WriteLine(i); // if the number doesn't pass any of the above condition it runs this, just displays the number
                }
            }
            //below line displays the total count of each required fields.
            Console.WriteLine("*******************************************************************************");
            Console.WriteLine($"There were total of {ss} sweet'nSalty, {sw} sweet, and {sl} salty shown");
        }
    }
}
