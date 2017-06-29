using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WebStore2.Domain.OrdersService;

namespace WebStore2.Hosting
{
    public class WebStoreService : IWebStoreService
    {
        Services.Services.DataBaseEngine m_dbe = new Services.Services.DataBaseEngine();

        public IEnumerable<ProductDataContract> GetProducts()
        {            
            var list = m_dbe.GetProducts();
            List<ProductDataContract> result = new List<ProductDataContract>();

            foreach (var p in list)
            {
                // маппинг сущности на ProductDataContract
                ProductDataContract pdc = new ProductDataContract
                {
                    id = p.id,
                    Name = p.Name,
                    Category = p.Category,
                    Price = p.Price
                };

                result.Add(pdc);
            }

            return result;
        }

        public IEnumerable<CategoryDataContract> GetCategories()
        {
            var list = m_dbe.GetCategories();
            List<CategoryDataContract> result = new List<CategoryDataContract>();

            foreach (var p in list)
            {
                // маппинг сущности на CategoryDataContract
                CategoryDataContract pdc = new CategoryDataContract
                {
                    id = p.id,
                    Name = p.Name,
                };

                result.Add(pdc);
            }

            return result;
        }

        public bool RemoveAt(int id)
        {
            return m_dbe.RemoveAt(id);
        }

        public void AddProduct(ProductDataContract pdc)
        {
            //  маппинг ProductDataContract на cущность
            Domain.Entities.Product p = new Domain.Entities.Product
            {
                Name = pdc.Name,
                Category = pdc.Category,
                Price = pdc.Price
            };

            m_dbe.Add(p);
        }

        public string GetData(int val)
        {
            return string.Format("Your code is {0}", val);
        }
    }
}
