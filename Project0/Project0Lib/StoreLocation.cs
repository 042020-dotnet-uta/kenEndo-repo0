using System;
using System.Collections.Generic;
using System.Text;

namespace Project0Lib
{
    public class StoreLocation
    {
        public int StoreId { get; set; } // Primary key to StoreItem
		public virtual StoreItem StoreItem { get; set; }


		private string _Location;

		public string Location
		{
			get { return _Location; }
			set { _Location = value; }
		}

		public StoreLocation(string location)
		{
			this.Location = location;
		}

	}
}
