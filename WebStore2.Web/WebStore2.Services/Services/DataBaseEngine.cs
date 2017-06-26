using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore2.Services.Services
{
    public class DataBaseEngine
    {
        readonly DAL.Context.WebStoreContext m_wc = new DAL.Context.WebStoreContext();

        public IEnumerable<Domain.Entities.Product> GetProducts()
        {
            return m_wc.Products;
        }

        public bool RemoveAt(int id)
        {
            bool result = false;
            var products = m_wc.Products.ToList();
            Domain.Entities.Product item = products.FirstOrDefault(x => x.id == id);            

            if (item != null)
            {
                products.Remove(item);
                result = true;
            }

            return result;
        }
    }
}
