using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.entity



namespace Project0Lib
{
    public class StoreItem
    {
        public int itemId { get; set; } //primary key to the item
		
		[ForeignKey("StoreItem")]
		public int StoreLocation { get; set; }//foreign key to store location
		public virtual StoreLocation Location { get; set; } //should be a foreign key to the store location(unsure if i should make the id foreign key or the name)



		private string _itemName;

		public string itemName
		{
			get { return _itemName; }
			set { _itemName = value; }
		}
		private int _itemPrice;

		public int itemPrice
		{
			get { return _itemPrice; }
			set { _itemPrice = value; }
		}
		private int _itemInventory;

		public int itemInventory
		{
			get { return _itemInventory; }
			set { _itemInventory = value; }
		}

		public StoreItem(StoreLocation itemstorelocationID, string itemname, int itemprice, int iteminventory)
		{
			this.StoreLocation = itemstorelocationID;
			this.itemName = itemname;
			this.itemPrice = itemprice;
			this.itemInventory = iteminventory;
		}
	}
}
