using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.Model.Entities;

namespace Singapor.DAL.Configurations
{
    public class UnitConfiguration : EntityTypeConfiguration<Unit>
    {
        public UnitConfiguration()
        {
            ToTable("Unit");
            HasKey(x => x.Id);
            Property(x => x.Description).IsRequired().HasMaxLength(50);
        }
    }
}
