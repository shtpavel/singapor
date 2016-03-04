using System.Data.Entity.ModelConfiguration;
using Singapor.Model.Entities;

namespace Singapor.DAL.Configurations
{
    public class CompanyDatabaseConfiguration : EntityTypeConfiguration<Company>
    {
        #region Constructors

        public CompanyDatabaseConfiguration()
        {
            ToTable("Company");
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(50);
            Property(x => x.Description).HasMaxLength(500);
        }

        #endregion
    }
}