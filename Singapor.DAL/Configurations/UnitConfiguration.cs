using System.Data.Entity.ModelConfiguration;
using Singapor.Model.Entities;

namespace Singapor.DAL.Configurations
{
    public class UnitConfiguration : EntityTypeConfiguration<Unit>
    {
        #region Constructors

        public UnitConfiguration()
        {
            ToTable("Unit");
            HasKey(x => x.Id);
            Property(x => x.Description).IsRequired().HasMaxLength(50);
        }

        #endregion
    }
}