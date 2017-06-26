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
    }
}
