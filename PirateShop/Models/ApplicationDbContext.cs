using Microsoft.AspNet.Identity.EntityFramework;
using PirateShop.Models.Items;
using System.Data.Entity;

namespace PirateShop.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<NinjaInventory> NinjaInventories { get; set; }

        //public ApplicationDbContext()
        //    : base("DefaultConnection", throwIfV1Schema: false)
        //{
        //}
        public ApplicationDbContext()
            : base("PirateShop", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}