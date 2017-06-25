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
                 Name = "������ ��� Assam",
                 Price = 123,
                 Category = "���"
             },

             new Product
             {
                 id = 2,
                 Name = "���� ������������",
                 Price = 211,
                 Category = "���"
             },

             new Product
             {
                 id = 3,
                 Name = "��� ������ � ����������",
                 Price = 300,
                 Category = "���"
             },

             new Product
             {
                 id = 4,
                 Name = "������� ���",
                 Price = 100,
                 Category = "���"
             },

             new Product
             {
                 id = 5,
                 Name = "���� ����������",
                 Price = 784,
                 Category = "����"
             }
             );

            context.SaveChanges();
        }
    }
}
