using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project0.OrderingFunc
{
    /// <summary>
    /// class to run the displaylocation class below
    /// </summary>
    class DisplayFunc
    {
        public void SeeStores()
        {
            DisplayLocations test = new DisplayLocations();
            test.DisplayingLocation(); //runs DisplayingLocation method from DisplayLocation
        }
    }
    /// <summary>
    /// DisplayLocations class displays all the location for the user to choose from and when
    /// a location is selected, it displays the list of items available in that specific location.
    /// </summary>
    public class DisplayLocations
    {
        List<StoreLocation> locations; //locations stores list of locations of all stores
        public List<StoreItem> storeItems; //storeItems stores list of all items from the user selected store
        internal static int input1 = 0; //static field to store user selected location
        string input; //stores user input to choose location

        /// <summary>
        /// displayingLocation is a method in DisplayLocation class that displays all store 
        /// location from StoreLocations table.
        /// </summary>
        public void DisplayingLocation()
        {
            using (var db = new AppDbContext())
            {
                Console.Clear();
                Console.WriteLine("\n**************************************************");
                Console.WriteLine("\n\t\tStore Locations\n");
                locations = db.StoreLocations.ToList(); //stores Storelocation table names into locations list
                foreach (StoreLocation x in locations) //prints all shop locations onto the console
                {
                    Console.WriteLine(x.StoreLocationId + "." + x.Location);
                }
            }
            Console.WriteLine("\n**************************************************");
            Console.WriteLine("Please enter the number(1~5) of location you would like to shop");
            input = Console.ReadLine();
            Console.WriteLine("\n**************************************************");
            if (!((int.TryParse(input, out input1)) && input1 <= 5 && input1 >= 1)) //input validation to make sure user entered a number between 1 - 5
            {
                Console.WriteLine("\nIncorrect input please enter a number from 1 ~ 5, enter to try again");
                Console.ReadLine();
                DisplayingLocation();
            }
        }
        /// <summary>
        /// selectingLocation method displays all the items from the location selected by user in displayingLocation method.
        /// </summary>
        public void ShowLocationItem()
        {
            Console.Clear();
            using (var db = new AppDbContext())
            {
                storeItems = db.StoreItems //stores items into a list
                    .Where(y => y.StoreLocation.StoreLocationId == input1).Include(y => y.StoreItemInventory).ToList();
                var selectedLocation = db.StoreLocations //stores location user selected
                    .First(x => x.StoreLocationId == input1);
                Console.WriteLine("\n**************************************************");
                Console.WriteLine($"\t\t{selectedLocation.Location} Pet Shop!\n\n ");
                foreach (StoreItem storeitem in storeItems)//displays all the item within the selected store
                {
                    Console.WriteLine("{0,-5}{1,-20}{2,15:C}{3,5}", storeitem.StoreItemId, 
                        storeitem.itemName, storeitem.itemPrice, storeitem.StoreItemInventory.itemInventory);
                }
                Console.WriteLine("**************************************************");
            }
        }
    }
}