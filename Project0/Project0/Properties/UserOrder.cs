using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    public class UserOrder
    {
        public int UserOrderId { get; set; } //PRIMARY KEY

        public UserInfo UserInfo { get; set; } //RELATION TO USERINFO

        public StoreItem StoreItem { get; set; } //RELATION TO STOREITEM

        private int _orderQuantity;

        public int orderQuantity //order quantity
        {
            get { return _orderQuantity; }
            set { _orderQuantity = value; }
        }

        private DateTime _timeStamp; //time stamp of order

        public DateTime timeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }
    }
}

