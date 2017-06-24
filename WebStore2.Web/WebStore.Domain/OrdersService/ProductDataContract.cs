using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


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

    public class MyProductDataContractConfiguration : EntityTypeConfiguration<ProductDataContract>
    {
        public MyProductDataContractConfiguration()
        {
            HasKey(x => x.id);

            Property(x => x.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.Name)
                .HasMaxLength(250)
                .IsRequired();

            Property(x => x.Category)
                .HasMaxLength(250)
                .IsRequired();

            Property(x => x.Price)
                .IsRequired();
        }
    }
}
