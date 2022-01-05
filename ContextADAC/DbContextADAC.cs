using ASG_ADAC_FE.CoreModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ASG_ADAC_FE.ContextADAC
{
    public class DbContextADAC : DbContext
    {
        public DbContextADAC(DbContextOptions<DbContextADAC> options)
           : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("adac_conn"));
            // base.OnConfiguring(optionsBuilder);
           // optionsBuilder.UseSqlServer(@"Server=EXTRAMILES;Database=dbecrss;Trusted_Connection=True;ConnectRetryCount=0");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //-------- Employee Mapping -------//
            modelBuilder.Entity<Employee>().HasKey(k => k.Id);
            modelBuilder.Entity<Employee>().Property(k => k.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Employee>().Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Employee>().Property(n => n.Email)
                .IsRequired()
                .HasMaxLength(50);

            //-------- Address Mapping -------//

            modelBuilder.Entity<Address>().HasKey(k => k.Id);
            modelBuilder.Entity<Address>().Property(k => k.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Address>().Property(n => n.FullAddress)
                .IsRequired()
                .HasMaxLength(20);

            //-----------------------------------//

            modelBuilder.Entity<Address>()
              .HasOne<Employee>(g => g.CurrentEmployeeAddress)
              .WithMany(s => s.EmployeeAddress)
              .HasForeignKey(s => s.EmployeeId);



            //--------- Seeding Intial Data --------//
            modelBuilder.Entity<Employee>().HasData(
                new { Id = 1, Name = "Randhawa", Email="ram.lubhaya1983@outlook.com", Active = true });

            modelBuilder.Entity<Address>().HasData(
                new { Id = 1, FullAddress = "United Arab Emirates", EmployeeId=1 });

        }
    }
   
}
