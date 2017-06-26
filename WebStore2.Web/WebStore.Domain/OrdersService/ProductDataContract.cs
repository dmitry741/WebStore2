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
        public int id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Price { get; set; }

        [DataMember]
        public string Category { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }    
}
