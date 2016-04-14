using System.Data.Entity.ModelConfiguration;
using Singapor.Model.Entities;

namespace Singapor.DAL.Configurations
{
	public class UtilityDatabaseConfiguration : EntityTypeConfiguration<Utility>
	{
		#region Constructors

		public UtilityDatabaseConfiguration()
		{
			ToTable("Utility");
			HasKey(x => x.Id);
		}

		#endregion
	}
}