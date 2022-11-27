using Microsoft.EntityFrameworkCore;
using TransportCompany.Domain.Entities;

namespace TransportCompany.DAL
{
    public class TransportCompanyContext : DbContext
    {
        public TransportCompanyContext(DbContextOptions<TransportCompanyContext> options)
            :base(options)
        {
        }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_exmp> Product_exmps { get; set; }
        public DbSet<Requare_product> Requare_products { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Transport_vehicle> Transport_vehicles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<BooksAuthorsEntity>().HasKey(u => new { u.AuthorID, u.ISBN });

            ////Настройка связи многие-ко-многим между товарами и складами
            //modelBuilder
            //.Entity<Product>()
            //.HasMany(c => c.Storages)
            //.WithMany(s => s.Products)
            //.UsingEntity<Product_exmp>(
            //   j => j
            //    .HasOne(pt => pt.Storage)
            //    .WithMany(t => t.Product_Exmps)
            //    .HasForeignKey(pt => pt.Storage_number),
            //j => j
            //    .HasOne(pt => pt.Product)
            //    .WithMany(p => p.Product_Exmps)
            //    .HasForeignKey(pt => pt.Сatalogue_number),
            //j =>
            //{
            //    j.HasKey(t => new { t.Storage_number, t.Сatalogue_number });
            //    j.ToTable("Product_exmp");
            //});
            modelBuilder.Entity<Requare_product>()
            .HasKey(m => new { m.RequestID, m.Сatalogue_number });

            modelBuilder.Entity<Product_exmp>()
            .HasKey(m => new { m.Storage_number, m.Сatalogue_number });


            modelBuilder.Entity<Request>().HasCheckConstraint("Number", "Number > 0");
        }
    }
}
