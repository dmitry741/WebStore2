﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WebStore2.Domain.OrdersService;

namespace WebStore2.Hosting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IWebStoreService
    {

        [OperationContract]
        IEnumerable<ProductDataContract> GetProducts();

    }

}