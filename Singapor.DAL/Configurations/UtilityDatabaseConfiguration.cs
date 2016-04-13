using System.Data.Entity.ModelConfiguration;
using Singapor.Model.Entities;

namespace Singapor.DAL.Configurations
{
	public class UtilityDatabaseConfiguration : EntityTypeConfiguration<Utility>
	{
		#region Constructors

		public UtilityDatabaseConfiguration()
		{
			ToTable("Service");
			HasKey(x => x.Id);
		}

		#endregion
	}
}