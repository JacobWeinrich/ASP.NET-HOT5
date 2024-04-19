using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_HOT3.Models.Identity;

namespace MVC_HOT3.Models
{
    public class TechStoreContext : IdentityDbContext<User>
    {
        public TechStoreContext(DbContextOptions<TechStoreContext> options) : base(options)
        {

        }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<PhoneOs> PhoneOs { get; set; }

        public DbSet<Purchase> Purchases { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PhoneOs>().HasData(
                new PhoneOs { PhoneOsID = 1, PhoneOsName = "iOS" },
                new PhoneOs { PhoneOsID = 2, PhoneOsName = "Android" }
                                                             );

            modelBuilder.Entity<Phone>().HasData(
                new Phone
                {
                    PhoneID = 1,
                    PhoneImageName = "Phone.png",
                    PhoneName = "iPhone 12",
                    PhoneBrand = "Apple",
                    PhoneModel = "A2403",
                    PhonePrice = 100.00,
                    PhoneOsID = 1
                },
                new Phone
                {
                    PhoneID = 6,
                    PhoneImageName = "Phone.png",
                    PhoneName = "iPhone 15",
                    PhoneBrand = "Apple",
                    PhoneModel = "A2403",
                    PhonePrice = 100.00,
                    PhoneOsID = 1
                },
                new Phone
                {
                    PhoneID = 2,
                    PhoneImageName = "Phone.png",
                    PhoneName = "Galaxy S21",
                    PhoneBrand = "Samsung",
                    PhoneModel = "SM-G991U",
                    PhonePrice = 100.00,
                    PhoneOsID = 2
                },
                new Phone
                {
                    PhoneID = 3,
                    PhoneImageName = "Phone.png",
                    PhoneName = "Pixel 5",
                    PhoneBrand = "Google",
                    PhoneModel = "GD1YQ",
                    PhonePrice = 100.00,
                    PhoneOsID = 2
                }, new Phone
                {
                    PhoneID = 4,
                    PhoneImageName = "Phone.png",
                    PhoneName = "Galaxy S22 Ulta",
                    PhoneBrand = "Samsung",
                    PhoneModel = "SM-G991U",
                    PhonePrice = 100.00,
                    PhoneOsID = 2
                }, new Phone
                {
                    PhoneID = 5,
                    PhoneImageName = "Phone.png",
                    PhoneName = "Galaxy S35 Ulta Super",
                    PhoneBrand = "Samsung",
                    PhoneModel = "SM-Z999A",
                    PhonePrice = 100.00,
                    PhoneOsID = 2
                }
               );
        }
    }
}
