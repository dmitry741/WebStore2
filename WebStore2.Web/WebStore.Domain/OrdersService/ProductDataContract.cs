using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WebStore2.Domain.OrdersService
{
    [DataContract]
    public class ProductDataContract
    {
        [DataMember]
        public string Name { get; set; }
    }
}
