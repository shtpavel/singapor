using System.Data.Entity.ModelConfiguration;
using Singapor.Model.Entities;

namespace Singapor.DAL.Configurations
{
	public class UserDatabaseConfiguration : EntityTypeConfiguration<User>
	{
		#region Constructors

		public UserDatabaseConfiguration()
		{
			ToTable("User");
			HasKey(x => x.Id);
		}

		#endregion
	}
}