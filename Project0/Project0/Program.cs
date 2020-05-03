using Project0.OrderingFunc;
using Project0.RegiAndLoginFunc;
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
            WelcomeNavigation test0 = new WelcomeNavigation();
            test0.Welcome();
        }
    }
}
