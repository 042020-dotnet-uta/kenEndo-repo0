using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Project0.Properties;

namespace Project0
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<StoreLocation> StoreLocations { get; set; }
        public DbSet<StoreItem> StoreItems { get; set; }
        public DbSet<StoreItemInventory> StoreItemInventories { get; set; }
        public DbSet<UserOrder> UserOrders { get; set; }
        public DbSet<UserOrderQuantity> UserOrderQuantities{ get; set; }
        public DbSet<UserOrderItem> UserOrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=Project0DB.db");
        }
    }
}
