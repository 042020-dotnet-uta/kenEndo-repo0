using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
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

        public AppDbContext() { }//for test

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }//for test

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=Project0DB.db");
            }
        }
    }
}
