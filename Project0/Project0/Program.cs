using Project0.OrderingFunc;

using System;
using System.Data.SQLite;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Project0.NavigationFunc;

namespace Project0
{
    class Program
    {
        static void Main(string[] args)
        {

            //UserRegistration test = new UserRegistration();
            //test.runRegistration();

            //OrderFunc test3 = new OrderFunc();
            //test3.StartOrder();

            DisplayAllUser test4 = new DisplayAllUser();
            test4.DisplayItAll();


        }
    }
}
