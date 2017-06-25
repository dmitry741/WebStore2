using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity;

namespace WebStore2.Services.Services
{
    public class DataBaseEngine
    {
        readonly DAL.Context.WebStoreContext _wc = new DAL.Context.WebStoreContext();

        public IEnumerable<Domain.Entities.Product> GetProducts()
        {
            return _wc.Products;
        }
    }
}
