using HamburgerAppMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace HamburgerAppMvc.Context
{
    public class HamburgerDbContext:DbContext
    {
        public HamburgerDbContext(DbContextOptions<HamburgerDbContext> options):base(options) 
        {
            
        }

        public virtual DbSet<Extra> Extras { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Menu>().HasData(
                new Menu() { MenuID = 1, MenuName = "Mass SteakHouse", Price = 150 },
                new Menu() { MenuID = 2, MenuName = "Double MassBurger", Price = 140 },
                new Menu() { MenuID = 3, MenuName = "Cheese & MassBurger", Price = 130 },
                new Menu() { MenuID = 4, MenuName = "MassBurger", Price = 120 }
                );

            modelBuilder.Entity<Extra>().HasData(
                new Extra() { ExtraID = 1, ExtraName = "Barbeque", Price = 10 },
                new Extra() { ExtraID = 2, ExtraName = "Ketchup", Price = 9 },
                new Extra() { ExtraID = 3, ExtraName = "Ranch", Price = 12 }
            );



            modelBuilder.Entity<Order>()
                        .HasMany(s => s.Extras)
                        .WithMany(c => c.Orders);
           
        }

    }
}
