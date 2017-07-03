using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WebStore2.Services.Services.Base
{
    [ServiceContract]
    public interface IDataBaseEngine
    {
        [OperationContract]
        IEnumerable<Domain.Entities.Product> GetProducts();

        [OperationContract]
        IEnumerable<Domain.Entities.Category> GetCategories();

        [OperationContract]
        bool RemoveAt(int id);

        [OperationContract]
        void Add(Domain.Entities.Product model);
    }
}
