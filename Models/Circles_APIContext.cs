using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Circles_API.Models
{
    public class Circles_APIContext : DbContext
    {
        public DbSet<Circle> Circles { get; set; }
        public DbSet<Userprofile> Userprofiles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<CircleUserprofile> CircleUserprofiles { get; set; }
        public DbSet<TagUserprofile> TagUserprofiles { get; set; }

        public Circles_APIContext(DbContextOptions<Circles_APIContext> options)
            : base(options)
        {
        }

        public Circles_APIContext()
        {

        }
    }
}