using System.Data.Entity.ModelConfiguration;
using Singapor.Model.Entities;

namespace Singapor.DAL.Configurations
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        #region Constructors

        public OrderConfiguration()
        {
            ToTable("Order");
            HasKey(x => x.Id);
            Property(x => x.Description).IsRequired().HasMaxLength(200);
            Property(x => x.StartTime).IsRequired();
            Property(x => x.EndTime).IsRequired();
        }

        #endregion
    }
}