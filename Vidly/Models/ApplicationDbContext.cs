using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vidly.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Membership entity
            modelBuilder.Entity<MembershipType>().HasData(
                new MembershipType { Id = 1,Name="S", SignUpFee = 0, DurationInMonths = 0, DiscountRate = 0 },
                new MembershipType { Id = 2, Name = "S", SignUpFee = 30, DurationInMonths = 1, DiscountRate = 10 },
                new MembershipType { Id = 3, Name = "S", SignUpFee = 90, DurationInMonths = 3, DiscountRate = 15 },
                new MembershipType { Id = 4, Name = "S", SignUpFee = 300, DurationInMonths = 14, DiscountRate = 20 }
                // Add more seed data as needed
            );

            // Configure the Customers entity
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Shakeel", IsSubscribedToNewsletter = false, MembershipTypeId= 1},
               new Customer { Id = 2, Name = "Bilal", IsSubscribedToNewsletter = true, MembershipTypeId = 2 }
                // Add more seed data as needed
            );

            // Configure the Genre entity
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action"},
                new Genre { Id = 2, Name = "Drama"}
            // Add more seed data as needed
            );
            // Configure the Movie entity
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Name = "John Wick", GenreId = 1 },
                new Movie { Id = 2, Name = "3 Idiots", GenreId = 2 }
            // Add more seed data as needed
            );




        }
        
    }
}
