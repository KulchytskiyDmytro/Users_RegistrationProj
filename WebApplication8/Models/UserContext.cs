using System.Data.Entity;

namespace WebApplication8.Models
{
    public class UserContext : DbContext
    {
        public UserContext() :
            base("DefaultConnection")
        {}
        public DbSet<User> Users { get; set; }
        public DbSet<Region> Regions { get; set; }
    }
}