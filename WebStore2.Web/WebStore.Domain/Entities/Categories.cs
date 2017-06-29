using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebStore2.Domain.Entities
{
    public class Category
    {
        public int id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class MyCategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public MyCategoryConfiguration()
        {
            HasKey(x => x.id);

            Property(x => x.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.Name)
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}
