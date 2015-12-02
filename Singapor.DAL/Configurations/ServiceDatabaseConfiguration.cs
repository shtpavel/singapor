using System.Data.Entity.ModelConfiguration;
using Singapor.Model.Entities;

namespace Singapor.DAL.Configurations
{
	public class ServiceDatabaseConfiguration : EntityTypeConfiguration<Service>
	{
		#region Constructors

		public ServiceDatabaseConfiguration()
		{
			ToTable("Service");
			HasKey(x => x.Id);
		}

		#endregion
	}
}