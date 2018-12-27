using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Equipment> Equipment { get; set; }

        public DbSet<Brand> Brand { get; set; }

        public DbSet<Tool> Tool { get; set; }
    }
}