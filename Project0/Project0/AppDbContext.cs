using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Project0Lib;
using DbContext = System.Data.Entity.DbContext;

namespace Project0
{
    public class AppDbContext : DbContext
    {
        public AppDbContext():base()
        {

        }
        public System.Data.Entity.DbSet<StoreItem> storeItems { get; set; }
        public System.Data.Entity.DbSet<StoreLocation> StoreLocations { get; set; }
    }
}
