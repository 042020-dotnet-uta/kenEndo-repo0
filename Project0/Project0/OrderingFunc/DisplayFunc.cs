using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Project0.OrderingFunc
{
    class DisplayFunc
    {

       public void SeeStores()
        {
            DisplayLocations test = new DisplayLocations();
            test.DisplayingLocation();
            test.SelectingLocation();

        }
    }
    /// <summary>
    /// DisplayLocations class displays all the location for the user to choose from and when
    /// a location is selected, it displays the list of items available in that specific location.
    /// </summary>
    public class DisplayLocations
    {
        /// <summary>
        /// locations stores list of locations of all stores
        /// storeItems stores list of all items from the user selected store
        /// </summary>
        List<StoreLocation> locations; 
        public List<StoreItem> storeItems;
        internal static int input1 = 0;
       /// <summary>
       /// displayingLocation is a method in DisplayLocation class that displays all store 
       /// location from StoreLocations table.
       /// </summary>
        public void DisplayingLocation() 
        { 
            using(var db = new AppDbContext())
            {
                Console.WriteLine("\n**************************************************");
                locations = db.StoreLocations.ToList(); //stores Storelocation table names into locations list
                foreach(StoreLocation x in locations) //prints all shop locations onto the console
                {
                    Console.WriteLine(x.StoreLocationId+ "." + x.Location);
                }
            }
            Console.WriteLine("\n**************************************************");
        }
        /// <summary>
        /// selectingLocation method displays all the items from the location selected by user in displayingLocation method.
        /// </summary>
        public void SelectingLocation()
        {
            Console.WriteLine("Please enter the number(1~5) of location you would like to shop");
            string input = Console.ReadLine();
            Console.WriteLine("\n**************************************************");
            if((int.TryParse(input, out input1)) && input1<=5 && input1 >= 1) //input validation to make sure user entered a number between 1 - 5
            {
                Console.Clear();
                using (var db = new AppDbContext())
                {
                    storeItems = db.StoreItems
                        .Where(y => y.StoreLocation.StoreLocationId == input1).Include(y=>y.StoreItemInventory).ToList();
                    var selectedLocation = db.StoreLocations
                        .First(x => x.StoreLocationId == input1);
                    Console.WriteLine("\n**************************************************");
                    Console.WriteLine($"\t\t{selectedLocation.Location} Pet Shop!\n\n ");
                    foreach (StoreItem storeitem in storeItems)
                    {
                        Console.WriteLine("{0,-5}{1,-20}{2,15:C}{3,5}", storeitem.StoreItemId, storeitem.itemName, storeitem.itemPrice, storeitem.StoreItemInventory.itemInventory);
                    }
                    Console.WriteLine("**************************************************");
                }
            }
            else
            {
                Console.WriteLine("\nIncorrect input please try again");
                SelectingLocation();
            }
        }
    }
}
