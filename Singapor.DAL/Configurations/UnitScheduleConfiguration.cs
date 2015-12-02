using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.Model.Entities;

namespace Singapor.DAL.Configurations
{
    public class UnitScheduleConfiguration : EntityTypeConfiguration<UnitSchedule>
    {
        public UnitScheduleConfiguration()
        {
            ToTable("UnitSchedule");
            HasKey(x => x.Id);
            Property(x => x.ExactDate).IsRequired();
            Property(x => x.Description).IsRequired().HasMaxLength(100);
        }
    }
}
