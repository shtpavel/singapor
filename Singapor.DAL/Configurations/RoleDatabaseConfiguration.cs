using System.Data.Entity.ModelConfiguration;
using Singapor.Model.Entities;

namespace Singapor.DAL.Configurations
{
	public class RoleDatabaseConfiguration : EntityTypeConfiguration<Role>
	{
		#region Constructors

		public RoleDatabaseConfiguration()
		{
			ToTable("Roles");
			HasKey(x => x.Id);
		}

		#endregion
	}
}