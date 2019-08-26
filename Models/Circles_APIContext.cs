using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Circles_API.Models
{
    public class Circles_APIContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Circle> Circles { get; set; }
        public DbSet<Userprofile> Userprofiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseMySql(@"server=localhost;user id=root;password=" + EnvironmentVariables.MySQLPW + ".;port=3306;database=circles;");

        public Circles_APIContext(DbContextOptions options) : base(options)
        {

        }
        public Circles_APIContext()
        {

        }
    }
}