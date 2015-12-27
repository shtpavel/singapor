using System.Data.Entity.ModelConfiguration;
using Singapor.Model.Entities;

namespace Singapor.DAL.Configurations
{
    public class UnitScheduleConfiguration : EntityTypeConfiguration<UnitSchedule>
    {
        #region Constructors

        public UnitScheduleConfiguration()
        {
            ToTable("UnitSchedule");
            HasKey(x => x.Id);
            Property(x => x.ExactDate).IsRequired();
            Property(x => x.Description).IsRequired().HasMaxLength(100);
        }

        #endregion
    }
}