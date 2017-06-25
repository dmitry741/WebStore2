namespace WebStore2.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using WebStore2.Domain.Entities;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebStore2.DAL.Context.WebStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebStore2.DAL.Context.WebStoreContext context)
        {
            context.Products.AddOrUpdate(e => e.id,
             new Product
             {
                 id = 1,
                 Name = "Черный чай Assam",
                 Price = 123,
                 Category = "Чай"
             },

             new Product
             {
                 id = 2,
                 Name = "Пуэр классический",
                 Price = 211,
                 Category = "Чай"
             },

             new Product
             {
                 id = 3,
                 Name = "Чай черный с бергамотом",
                 Price = 300,
                 Category = "Чай"
             },

             new Product
             {
                 id = 4,
                 Name = "Зеленый чай",
                 Price = 100,
                 Category = "Чай"
             },

             new Product
             {
                 id = 5,
                 Name = "Кофе Марагоджип",
                 Price = 784,
                 Category = "Кофе"
             }
             );

            context.SaveChanges();
        }
    }
}
