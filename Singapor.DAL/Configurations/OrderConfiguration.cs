using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.Model.Entities;

namespace Singapor.DAL.Configurations
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            ToTable("Order");
            HasKey(x => x.Id);
            Property(x => x.Description).IsRequired().HasMaxLength(200);
            Property(x => x.StartTime).IsRequired();
            Property(x => x.EndTime).IsRequired();
        }
    }
}
