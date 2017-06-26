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
        public IEnumerable<ProductDataContract> GetProducts()
        {
            Services.Services.DataBaseEngine dbe = new Services.Services.DataBaseEngine();
            var list = dbe.GetProducts();
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

        public bool RemoveAt(int id)
        {
            Services.Services.DataBaseEngine dbe = new Services.Services.DataBaseEngine();

            return dbe.RemoveAt(id);
        }

        public void AddProduct(ProductDataContract pdc)
        {
            Services.Services.DataBaseEngine dbe = new Services.Services.DataBaseEngine();

            //  маппинг ProductDataContract на cущность
            Domain.Entities.Product p = new Domain.Entities.Product
            {
                Name = pdc.Name,
                Category = pdc.Category,
                Price = pdc.Price
            };

            dbe.Add(p);
        }

        public string GetData(int val)
        {
            return string.Format("Your code is {0}", val);
        }
    }
}
