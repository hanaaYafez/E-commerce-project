using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data
{
    public class ApplicationDbContext: IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        { }
        public DbSet<Product> products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Cart> cart { get; set; }
        public DbSet<CartItem> cartItems { get; set; }
        //public DbSet<RegistrationViewModel> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "admin",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = "user",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
