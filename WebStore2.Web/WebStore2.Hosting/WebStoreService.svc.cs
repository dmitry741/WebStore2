using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Mvc;
using WebStore2.Domain.OrdersService;
using Ninject;

namespace WebStore2.Hosting
{
    public class FirstDiscountHelper : IDiscountHelper
    {
        public int GetDiscount(int price)
        {
            return 1;
        }
    }

    public class WebStoreService : IWebStoreService
    {
        Services.Services.Base.IDataBaseEngine m_dbe;
        IDiscountHelper m_dh;

        public WebStoreService()
        {
            IKernel standartKernel = new StandardKernel();
            NinjectDependencyResolver ndr = new NinjectDependencyResolver(standartKernel);
            IKernel ninjectKernel = ndr.GetKernel();

            m_dbe = ninjectKernel.Get<Services.Services.Base.IDataBaseEngine>();
            m_dh = ninjectKernel.Get<IDiscountHelper>();
        }

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
                    Price = p.Price - m_dh.GetDiscount(p.Price)
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

        public override string ToString()
        {
            return "The first realisation";
        }
    }
}
