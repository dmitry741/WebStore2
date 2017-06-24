using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebStore2.Domain.OrdersService;

namespace WebStore2.DAL.Context
{
    public class WebStoreContext : System.Data.Entity.DbContext
    {
        public WebStoreContext() : base("Context") { }

        public DbSet<ProductDataContract> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MyProductDataContractConfiguration());
        }
    }
}
