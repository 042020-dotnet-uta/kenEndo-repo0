using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
	public class StoreItemInventory
	{
		public int StoreItemInventoryId { get; set; } //PRIMARY KEY

		private int _itemInventory; //inventory of item

		public int itemInventory
		{
			get { return _itemInventory; }
			set { _itemInventory = value; }
		}

	}
}
