using System.Data.Entity.ModelConfiguration;
using Singapor.Model.Entities;

namespace Singapor.DAL.Configurations
{
	public class UnitDatabaseConfiguration : EntityTypeConfiguration<Unit>
	{
		#region Constructors

		public UnitDatabaseConfiguration()
		{
			ToTable("Unit");
			HasKey(x => x.Id);
			Property(x => x.Description).IsRequired().HasMaxLength(50);
		}

		#endregion
	}
}