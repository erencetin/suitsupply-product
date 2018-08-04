namespace SuitSupplyAssessment.ProductCatalog.DataModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SuitSupplyAssessment.ProductCatalog.DataModel.ProductContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SuitSupplyAssessment.ProductCatalog.DataModel.ProductContext";
        }

        protected override void Seed(SuitSupplyAssessment.ProductCatalog.DataModel.ProductContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
