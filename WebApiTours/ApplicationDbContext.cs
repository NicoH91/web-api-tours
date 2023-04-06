using Microsoft.EntityFrameworkCore;
using WebApiTours.Entity;

namespace WebApiTours
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelbuilder) //Sin esta linea identity no va a funcionar. 
        {
            base.OnModelCreating(modelbuilder);
        }

        public DbSet<Tour> Tours { get; set; }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<Detail> Details { get; set; }

        public DbSet<Challenge> Challenges { get; set; }

        public DbSet<Login> Logins { get; set; }


    }

}