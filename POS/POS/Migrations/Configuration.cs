using PosClassLibrary;

namespace POS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<POS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(POS.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            context.Items.AddOrUpdate(
                i => i.Id,
                new Item {Name = "Pen", Price = 5},
                new Item {Name = "Shirt", Price = 100},
                new Item {Name = "Cap", Price = 50});

            context.Stocks.AddOrUpdate(
                s => s.Id,
                new Stock { ItemId = 1, Quantity = 10},
                new Stock { ItemId = 2, Quantity = 20},
                new Stock { ItemId = 3, Quantity = 5}
                );


        }
    }
}
