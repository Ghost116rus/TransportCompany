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

        public DbSet<User> Users { get; set; }

        public DbSet<Distance> Distances { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Locations> locations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_exmp> Product_exmps { get; set; }
        public DbSet<Requare_product> Requare_products { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Transport_vehicle> Transport_vehicles { get; set; }
        public DbSet<Transportation> Transportations{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<BooksAuthorsEntity>().HasKey(u => new { u.AuthorID, u.ISBN });

            // Настройка двойного внешнего ключа
            modelBuilder.Entity<Distance>(entity =>
            {
                entity.HasOne(d => d.StartPoint)
                    .WithMany(p => p.LocationsStartPoints)
                    .HasForeignKey(d => d.StartP)
                    .OnDelete(DeleteBehavior.ClientNoAction)
                    .HasConstraintName("FK_Distance_Locations_StartPoint");

                entity.HasOne(d => d.EndPoint)
                    .WithMany(p => p.LocationsEndsPoints)
                    .HasForeignKey(d => d.EndP)
                    .OnDelete(DeleteBehavior.ClientNoAction)
                    .HasConstraintName("FK_Distance_Locations_EndPoint");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.HasOne(r => r.RecievingStorage)
                    .WithMany()
                    .HasForeignKey(r => r.Num_Receiving_storage)
                    .OnDelete(DeleteBehavior.ClientNoAction);
            });

            modelBuilder.Entity<Transportation>(entity =>
            {
                entity.HasOne(t => t.SendingStorage)
                    .WithMany()
                    .HasForeignKey(t => t.Num_Sending_storage)
                    .OnDelete(DeleteBehavior.ClientNoAction);
            });

            modelBuilder.Entity<Requare_product>()
            .HasKey(m => new { m.RequestID, m.Сatalogue_number });

            modelBuilder.Entity<Product_exmp>()
            .HasKey(m => new { m.Storage_number, m.Сatalogue_number });

            modelBuilder.Entity<Distance>()
            .HasKey(m => new { m.StartP, m.EndP });

            // Ограничение пользователя
            modelBuilder.Entity<User>()
                .HasCheckConstraint("ForignKeyToStorage", "ForignKeyToStorage > 0");

            modelBuilder.Entity<User>()
                .HasCheckConstraint("TypeOfUser", "TypeOfUser >= 0 AND TypeOfUser < 3");

            // Ограничения заявки

            modelBuilder.Entity<Request>().HasCheckConstraint("Number", "Number > 0");
            modelBuilder.Entity<Request>()
                .HasCheckConstraint("Status", "Status LIKE 'Обрабатывается' OR Status LIKE 'Сформирована' OR Status LIKE 'Доставляется' OR Status LIKE 'Выполнена' OR Status LIKE 'Отказано'");
            modelBuilder.Entity<Request>().HasCheckConstraint("Num_Receiving_storage", "Num_Receiving_storage > 0");
            modelBuilder.Entity<Request>().HasCheckConstraint("Total_mass", "Total_mass > 0");
            modelBuilder.Entity<Request>().HasCheckConstraint("Total_cost", "Total_cost > 0");
            modelBuilder.Entity<Request>().HasCheckConstraint("Total_volume", "Total_volume > 0");

            // Ограничения поставки
            modelBuilder.Entity<Transportation>().HasCheckConstraint("Number", "Number > 0");
            modelBuilder.Entity<Transportation>().HasCheckConstraint("Num_Sending_storage", "Num_Sending_storage > 0");
            modelBuilder.Entity<Transportation>().HasCheckConstraint("Total_length", "Total_length > 0");
            modelBuilder.Entity<Transportation>().HasCheckConstraint("Car_load", "Car_load > 0");
            modelBuilder.Entity<Transportation>().HasCheckConstraint("Total_shipping_cost", "Total_shipping_cost > 0");

            // Ограничения товара
            modelBuilder.Entity<Product>()
                .HasCheckConstraint("Type", "Type LIKE 'крупногабаритный' OR Type LIKE 'малогабаритный'");
            modelBuilder.Entity<Product>().HasCheckConstraint("Length", "Length > 0");
            modelBuilder.Entity<Product>().HasCheckConstraint("Width", "Width > 0");
            modelBuilder.Entity<Product>().HasCheckConstraint("Height", "Height > 0");
            modelBuilder.Entity<Product>().HasCheckConstraint("Weight", "Weight > 0");
            modelBuilder.Entity<Product>().HasCheckConstraint("Cost", "Cost > 0");


            // Ограничения склада
            modelBuilder.Entity<Storage>()
                .HasCheckConstraint("Storage_number", "Storage_number > 0");
            modelBuilder.Entity<Storage>()
                .HasIndex(u => u.Phone_number).IsUnique();

            // Ограничения водителя
            modelBuilder.Entity<Driver>()
                .HasIndex(u => u.Phone_number).IsUnique();
            modelBuilder.Entity<Driver>().
                HasCheckConstraint("Year_of_start_work", "Year_of_start_work LIKE '[1-2][0,1,9][0-9][0-9]'");
            modelBuilder.Entity<Driver>()
                .HasCheckConstraint("Status", "Status LIKE 'Свободен' OR Status LIKE 'В рейсе' OR Status LIKE 'На больничном'");



            // Ограничения тс
            modelBuilder.Entity<Transport_vehicle>()
                .HasCheckConstraint("Status", "Status LIKE 'Свободен' OR Status LIKE 'В рейсе' OR Status LIKE 'В ремонте'");
            modelBuilder.Entity<Transport_vehicle>()
                .HasCheckConstraint("Transported_volume", "Transported_volume > 0");
            modelBuilder.Entity<Transport_vehicle>()
                .HasCheckConstraint("Load_capacity", "Load_capacity > 0");
            modelBuilder.Entity<Transport_vehicle>()
                .HasCheckConstraint("Fuel_consumption", "Fuel_consumption > 0");


            modelBuilder.Entity<Product_exmp>()
                .HasCheckConstraint("Storage_number", "Storage_number > 0");
            modelBuilder.Entity<Requare_product>().HasCheckConstraint("RequestID", "RequestID > 0");

            // вспомогательные таблицы
            modelBuilder.Entity<Distance>()
                .HasCheckConstraint("StartP", "StartP > 0");
            modelBuilder.Entity<Distance>()
                .HasCheckConstraint("EndP", "EndP > 0");
        }

    }
}
