using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MilmomStore_BusinessObject.Model
{
    public class MilmomSystemContext : IdentityDbContext<AccountApplication>
    {
        public MilmomSystemContext(DbContextOptions<MilmomSystemContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Transaction>()
                .HasOne(e => e.Order)
            .WithOne(e => e.Transaction)
                .HasForeignKey<Order>(e => e.transactionID)
                .IsRequired();
            modelBuilder.Entity<ShippingInfor>()
                .HasOne(e => e.Order)
                .WithOne(e => e.ShippingInfor)
                .HasForeignKey<Order>(e => e.ShippingInforID)
                .IsRequired();
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                },
                 new IdentityRole
                {
                    Name = "Staff",
                    NormalizedName = "STAFF"
                },
                  new IdentityRole
                {
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }

        //
        public DbSet<Blog> Blogs { set; get; }
        public DbSet<CartItem> CartItems { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<ImageProduct> ImageProducts { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<Rating> Rating { set; get; }
        public DbSet<Report> Reports { set; get; }
        public DbSet<Review> Reviews { set; get; }
        public DbSet<ShippingInfor> ShippingInfor { set; get; }
        public DbSet<Slider> Slider { set; get; }
        public DbSet<Transaction> Transaction { set; get; }
        //
        //    public const string ConnectStrring = @"Data Source=localhost,1433;Initial Catalog=MilmomStore_Db;User ID=sa;Password=12345";

        //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    {
        //        optionsBuilder.UseSqlServer(ConnectStrring);
        //        optionsBuilder.UseLoggerFactory(GetLoggerFactory());       // bật logger
        //    }

        //    private ILoggerFactory GetLoggerFactory()
        //    {
        //        IServiceCollection serviceCollection = new ServiceCollection();
        //        serviceCollection.AddLogging(builder =>
        //            builder.AddConsole()
        //                .AddFilter(DbLoggerCategory.Database.Command.Name,
        //                    LogLevel.Information));
        //        return serviceCollection.BuildServiceProvider()
        //            .GetService<ILoggerFactory>();
        //    }
    }
}
