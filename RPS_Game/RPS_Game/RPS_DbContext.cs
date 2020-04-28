using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;


namespace RPS_Game
{
    public class RPS_DbContext:DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options )
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("Data source=rpsGame.db");

            }
        }

        public RPS_DbContext() { }

        public RPS_DbContext(DbContextOptions<RPS_DbContext> options) : base(options) { }
    }
}
