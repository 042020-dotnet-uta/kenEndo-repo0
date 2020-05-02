using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Project0.Functionalities
{
    class DisplayFunc
    {
       public List<StoreItem> seeStores()
        {
            DisplayLocations test = new DisplayLocations();
            test.displayingLocation();
            List<StoreItem> selectedStore = test.selectingLocation();
            return selectedStore;
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
       /// <summary>
       /// displayingLocation is a method in DisplayLocation class that displays all store 
       /// location from StoreLocations table.
       /// </summary>
        public void displayingLocation() 
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
        public List<StoreItem> selectingLocation()
        {
            Console.WriteLine("Please enter the number(1~5) of location you would like to shop");
            string input = Console.ReadLine();
            Console.WriteLine("\n**************************************************");
            if((int.TryParse(input, out int input1)) && input1<=5 && input1 >= 1) //input validation to make sure user entered a number between 1 - 5
            {
                Console.Clear();
                using (var db = new AppDbContext())
                {
                    storeItems = db.StoreItems
                        .Where(y => y.StoreLocation.StoreLocationId == input1).Include(y=>y.StoreItemInventory).ToList();
                    var selectedLocation = db.StoreLocations
                        .First(x => x.StoreLocationId == input1);
                    Console.WriteLine("\n**************************************************");
                    Console.WriteLine($"{selectedLocation.Location} Pet Shop!\n ");
                   foreach(StoreItem storeitem in storeItems)
                    {
                        Console.WriteLine(storeitem.StoreItemId + ". " + storeitem.itemName + "\t$"   + storeitem.itemPrice + "\tCount:" + storeitem.StoreItemInventory.itemInventory);
                    }
                    Console.WriteLine("**************************************************");
                }
            }
            else
            {
                Console.WriteLine("\nIncorrect input please try again");
                selectingLocation();
            }
            return storeItems;
        }

    }


}
