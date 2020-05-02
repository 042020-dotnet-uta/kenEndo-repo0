using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Properties
{
    public class UserOrderItem
    {
        public int UserOrderItemId { get; set; }
        public virtual StoreItem StoreItem { get; set; }
        public virtual UserOrder UserOrder { get; set; }


    }
}
