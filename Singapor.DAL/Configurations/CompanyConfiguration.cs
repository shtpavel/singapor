using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.Model.Entities;

namespace Singapor.DAL.Configurations
{
    public class CompanyConfiguration : EntityTypeConfiguration<Company>
    {
        public CompanyConfiguration()
        {
            ToTable("Company");
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(50);
            Property(x => x.Description).HasMaxLength(500);
        }
    }
}
