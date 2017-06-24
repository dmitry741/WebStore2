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
            throw new NotImplementedException();
        }
    }
}
