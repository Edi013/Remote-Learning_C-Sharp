using System.Configuration;
using iQuest.VendingMachine.Business;
using Microsoft.EntityFrameworkCore;

namespace iQuest.VendingMachine.DataAcces
{
    public class VmDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }

        public VmDbContext() 
            : base() 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

            optionsBuilder.UseSqlServer(connectionString); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>().HasKey(p => p.ColumnId);
            modelBuilder.Entity<Product>()
                .Property(p => p.ColumnId)
                .ValueGeneratedNever()
                .IsRequired();

            modelBuilder.Entity<Product>()
               .Property(p => p.Price)
               .HasMaxLength(65536)
               .IsRequired();

            modelBuilder.Entity<Product>()
               .Property(p => p.Quantity)
               .HasMaxLength(256)
               .IsRequired();

            modelBuilder.Entity<Product>()
               .Property(p => p.Name)
               .HasMaxLength(40)
               .IsRequired();


            modelBuilder.Entity<Sale>().ToTable("Sales");
            modelBuilder.Entity<Sale>().HasKey(p => p.Id);

            modelBuilder.Entity<Sale>()
              .Property(p => p.ProductName)
              .HasMaxLength(25)
              .IsRequired();

            modelBuilder.Entity<Sale>()
               .Property(p => p.Date)
               .IsRequired();

            modelBuilder.Entity<Sale>()
              .Property(p => p.PaymentMethod)
              .HasMaxLength(25)
              .IsRequired();

            modelBuilder.Entity<Sale>()
              .Property(p => p.Price)
              .IsRequired();

        }
    }
}
