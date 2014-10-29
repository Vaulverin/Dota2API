using System.Data.Entity;

namespace Dota2API.Models
{
    public class Dota2APIContext : DbContext
    {
        public Dota2APIContext() : base("name=Dota2APIContext")
        {
        }

        public DbSet<NewsModel> News { get; set; }
        public DbSet<ResourcesModel> Resources { get; set; }
        public DbSet<LeaguesModel> Leagues { get; set; }
    }
}
