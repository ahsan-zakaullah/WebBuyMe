using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebbuyMe.Models;

namespace WebbuyMe.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProductTypes> productTypes { get; set; }
        public DbSet<SpecialTags> specialTags { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<Appointments>  appointments { get; set; }
        public DbSet<ProductsSelectedForAppointment> productsSelectedForAppointments { get; set; }
    }
}
