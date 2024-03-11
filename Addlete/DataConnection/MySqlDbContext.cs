using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Addlete.Models;

namespace produkto.DataConnection
{
    public class MySqlDbContext:DbContext
    {
 
        public DbSet<User> Users { get; set; }

        public DbSet<Coach> Coaches { get; set; } // Add DbSet for Coach mode

        public DbSet<Athlete> Athletes { get; set; } // Add DbSet for Coach mode

        public DbSet<Injury_Reports> Injury_Reports { get; set; } // Add DbSet for Coach mode


        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options) { }
    }
}
