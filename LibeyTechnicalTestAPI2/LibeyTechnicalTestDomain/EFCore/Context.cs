using LibeyTechnicalTestDomain.EFCore.Configuration;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore;
namespace LibeyTechnicalTestDomain.EFCore
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<LibeyUser> LibeyUsers { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<Ubigeo> Ubigeo { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LibeyUserConfiguration());
         
            modelBuilder.Entity<Region>().HasKey(x => new { x.RegionCode });

            modelBuilder.Entity<Province>().HasKey(x => new { x.ProvinceCode });

            modelBuilder.Entity<Ubigeo>().HasKey(x => new { x.UbigeoCode });

            modelBuilder.Entity<DocumentType>().HasKey(x => new { x.DocumentTypeId });
        }
    }
}