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

        public IEnumerable<Domain.Entities.Category> GetCategories()
        {
            return m_wc.Categories;
        }

        public bool RemoveAt(int id)
        {
            bool result = false;
            var products = m_wc.Products;
            Domain.Entities.Product item = products.FirstOrDefault(x => x.id == id);            

            if (item != null)
            {
                products.Remove(item);
                m_wc.SaveChanges();
                result = true;
            }

            return result;
        }

        public void Add(Domain.Entities.Product model)
        {
            m_wc.Products.Add(model);
            m_wc.SaveChanges();
        }
    }
}
