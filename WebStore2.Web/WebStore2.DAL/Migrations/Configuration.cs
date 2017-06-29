namespace WebStore2.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using WebStore2.Domain.Entities;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.WebStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context.WebStoreContext context)
        {
             context.Products.AddOrUpdate(e => e.id,
             new Product
             {
                 Name = "Черный чай Assam",
                 Price = 123,
                 Category = "Чай"
             },

             new Product
             {
                 Name = "Пуэр классический",
                 Price = 211,
                 Category = "Чай"
             },

             new Product
             {
                 Name = "Чай черный с бергамотом",
                 Price = 300,
                 Category = "Чай"
             },

             new Product
             {
                 Name = "Зеленый чай",
                 Price = 100,
                 Category = "Чай"
             },

             new Product
             {
                 Name = "Кофе Марагоджип",
                 Price = 784,
                 Category = "Кофе"
             }
             );

            context.Categories.AddOrUpdate(с => с.id,
             new Category
             {
                 Name = "Чай"
             },

             new Category
             {
                 Name = "Кофе"
             }
             );

            context.SaveChanges();
        }
    }
}
