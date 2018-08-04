using System;
using System.Data.Entity;
using System.Linq;
using SuitSupplyAssessment.ProductCatalog.Model;
namespace SuitSupplyAssessment.ProductCatalog.DataAccess
{


    public class ProductContext : DbContext
    {
        // Your context has been configured to use a 'Product' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SuitSupplyAssesment.Product.DataAccess.Product' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Product' 
        // connection string in the application configuration file.
        public ProductContext()
            : base("name=Product")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<ProductContext>(null);
            //base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Product> Products { get; set; }
    }


}