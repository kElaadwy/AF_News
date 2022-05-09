using AFNews.Models;
using Microsoft.EntityFrameworkCore;

namespace AFNews.Data
{
    public class NewsDbContext : DbContext
    {
        public NewsDbContext (DbContextOptions<NewsDbContext> options) : base(options)
        {

        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<ContactUs> Contacts{ get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }


    }

}
