using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using System.Data.Entity.ModelConfiguration.Conventions;
using Store.Entity.Product;
using Store.Entity.Order;
using Store.Models;

namespace Store.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
       
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        //products tables
        public DbSet<ProductSize>productSize { get; set; }
        public DbSet <ProductColor>productColor { get; set; }
        public DbSet <ProductBrand>productBrand { get; set; }
        public DbSet<ProductSubCategory> productSubCategory { get; set; }
        public DbSet<ProductCategory> productCategory { get; set; }
        public DbSet<ProductMaster> productMaster { get; set; }
        public DbSet<ProductImages> productImages { get; set; }
        public DbSet<ProductReviews> productReviews { get; set; }
        //order tables
        public DbSet<OrderMaster> orderMaster { get; set; }
        public DbSet<OrderDetails> orderDetails { get; set; }

      
    }
}