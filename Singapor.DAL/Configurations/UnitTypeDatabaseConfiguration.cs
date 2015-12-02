using System.Data.Entity.ModelConfiguration;
using Singapor.Model.Entities;

namespace Singapor.DAL.Configurations
{
	public class UnitTypeDatabaseConfiguration : EntityTypeConfiguration<UnitType>
	{
		#region Constructors

		public UnitTypeDatabaseConfiguration()
		{
			ToTable("UnitType");
			HasKey(x => x.Id);
		}

		#endregion
	}
}