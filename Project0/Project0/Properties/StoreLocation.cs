using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
	public class StoreLocation
	{
		public int StoreLocationId { get; set; } //PRIMARY KEY
		public virtual List<StoreItem> StoreItem { get; set; } //RELATION TO STOREITEM

		private string _Location;

		public string Location // name of location
		{
			get { return _Location; }
			set { _Location = value; }
		}
	}
}
