using System;
using System.Collections.Generic;
using System.Text;

namespace Project0Lib
{
    public class StoreInfo
    {

        StoreItem item = new StoreItem(location, "Chicken", 10, 6);
    }



    public class LocationInfos
    {
        StoreLocation location = new StoreLocation("Houston");
        StoreLocation location1 = new StoreLocation("Austin");
        StoreLocation location2 = new StoreLocation("Dallas");
        StoreLocation location3 = new StoreLocation("San Antonio");
        StoreLocation location4 = new StoreLocation("Midland");

    }
}
