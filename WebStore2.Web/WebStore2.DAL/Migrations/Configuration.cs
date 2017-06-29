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
                 Name = "������ ��� Assam",
                 Price = 123,
                 Category = "���"
             },

             new Product
             {
                 Name = "���� ������������",
                 Price = 211,
                 Category = "���"
             },

             new Product
             {
                 Name = "��� ������ � ����������",
                 Price = 300,
                 Category = "���"
             },

             new Product
             {
                 Name = "������� ���",
                 Price = 100,
                 Category = "���"
             },

             new Product
             {
                 Name = "���� ����������",
                 Price = 784,
                 Category = "����"
             }
             );

            context.Categories.AddOrUpdate(� => �.id,
             new Category
             {
                 Name = "���"
             },

             new Category
             {
                 Name = "����"
             }
             );

            context.SaveChanges();
        }
    }
}
