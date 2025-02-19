namespace Etkinlik_CodeFirstAndMVC.Migrations
{
    using Etkinlik_CodeFirstAndMVC.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Etkinlik_CodeFirstAndMVC.Models.EtkinlikModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        

        protected override void Seed(Etkinlik_CodeFirstAndMVC.Models.EtkinlikModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
