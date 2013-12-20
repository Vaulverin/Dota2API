using System.Data.Entity;

namespace Dota2API.Models
{
    public class Dota2APIContext : DbContext
    {
        public Dota2APIContext() : base("name=Dota2APIContext")
        {
        }

        public DbSet<News> News { get; set; }
        public DbSet<Resources> Resources { get; set; }
    }
}
