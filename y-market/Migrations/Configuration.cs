namespace y_market.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<y_market.Models.y_marketContext>
    {//activar automaicamente 
        // enable-migrations -contextTypeName y_marketContext -enableAutomaticMigrations
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;//aotomatico
            AutomaticMigrationDataLossAllowed = true;//pierde datos cuando no concuerdan 
            ContextKey = "y_market.Models.y_marketContext";
        }

        protected override void Seed(y_market.Models.y_marketContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
