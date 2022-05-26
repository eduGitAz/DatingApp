using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{

    public class DataContext : IdentityDbContext<AppUser, AppRole, int, 
                                IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
                                IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppCompany> Companies { get; set; }
        public DbSet<AppCustomer> Customers { get; set; }
        public DbSet<AppDevice> Devices { get; set; }
        public DbSet<AppOrder> Orders { get; set; }
        public DbSet<AppOrderStatus> OrderStatuses { get; set; }
        public DbSet<AppOrderType> OrderTypes { get; set; }
        public DbSet<AppUseOfRefrigernat> UseOfRefrigernats { get; set; }
        public DbSet<AppRefrigerant> Refrigerants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.Entity<AppOrder>()
                .HasOne<AppCustomer>(c => c.AppCustomer)
                .WithMany(o => o.Orders)
                .HasForeignKey(c => c.CustomerId);

            builder.Entity<AppOrder>()
                .HasOne<AppDevice>(c => c.AppDevice)
                .WithMany(o => o.Orders)
                .HasForeignKey(c => c.DeviceId)
                .OnDelete(DeleteBehavior.Cascade);
              

            builder.Entity<AppOrder>()
                .HasOne<AppOrderStatus>(c => c.AppOrderStatus)
                .WithMany(o => o.Orders)
                .HasForeignKey(c => c.OrderStatusId);
            
            builder.Entity<AppOrder>()
                .HasOne<AppOrderType>(c => c.AppOrderType)
                .WithMany(o => o.Orders)
                .HasForeignKey(c => c.OrderTypeId);
            
            builder.Entity<AppOrder>()
                .HasOne<AppUseOfRefrigernat>(c => c.AppUseOfRefrigernat)
                .WithMany(o => o.Orders)
                .HasForeignKey(c => c.UseOfRefrigernatId);
            
            builder.Entity<AppOrder>()
                .HasOne<AppRefrigerant>(c => c.AppRefrigerant)
                .WithMany(o => o.Orders)
                .HasForeignKey(c => c.RefrigerantId);
        }      
        }
    }
