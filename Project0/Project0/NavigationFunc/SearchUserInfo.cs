using Project0.Properties;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Project0.NavigationFunc
{
    class SearchUserInfo
    {

    }


    class DisplayAllUser
    {

        internal void DisplayItAll()
        {
            using(var db = new AppDbContext())
            {
                Console.Clear();
                var listOfUsers = db.UserInfos.ToList();
                Console.WriteLine("Id\t\tUsername\n");
                foreach(var user in listOfUsers)
                {
                    Console.WriteLine($"{user.UserInfoId}\t\t{user.userName}");
                }


                Console.WriteLine("\nSelect the username Id to view their order histories");
                if(int.TryParse(Console.ReadLine(),out int selectedUserId))
                {
                    var userOrder = db.UserOrders.Where(x => x.UserInfo.UserInfoId == selectedUserId);
                    Console.WriteLine("\nId\t\tOrder Time\n");
                    foreach (var x in userOrder)
                    {
                        Console.WriteLine($"{x.UserOrderId}\t\t{x.timeStamp}");
                    }
                    if(int.TryParse(Console.ReadLine(),out int selectedOrderId))
                    {
                    var userOrder1 = db.UserOrders.Where(x=>x.UserOrderId == selectedOrderId).Include(x=>x.UserOrderItems).

                    }



                    //var showUserOrder = db.UserInfos.Include(x=>x.UserInfoId==userOrder.)
                }
            }
        }
    }
}
