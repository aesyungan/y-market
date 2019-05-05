using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace y_market.Models
{
    public class y_marketContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public y_marketContext() : base("name=y_marketContext")
        {
        }
        //para q no borre en cascada
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
          //  base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<y_market.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<y_market.Models.DocumentType> DocumentTypes { get; set; }

        public System.Data.Entity.DbSet<y_market.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<y_market.Models.Supplier> Suppliers { get; set; }

        public System.Data.Entity.DbSet<y_market.Models.Customer> Customers { get; set; }
        public System.Data.Entity.DbSet<y_market.Models.Order> Orders { get; set; }
        public System.Data.Entity.DbSet<y_market.Models.OrderDetail> OrderDetails { get; set; }
    }
}
