using System.Data.Entity;
using Singapor.DAL.Configurations;

namespace Singapor.DAL
{
	public class DataContext : DbContext, IDataContext
	{
		#region Constructors

		public DataContext() : base("name=Default")
		{
		}

		#endregion

		#region Public methods

		public IDbSet<T> Set<T>() where T : class
		{
			return base.Set<T>();
		}

		#endregion

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Configurations.Add(new CompanyDatabaseConfiguration());
			modelBuilder.Configurations.Add(new UnitDatabaseConfiguration());
			modelBuilder.Configurations.Add(new UserDatabaseConfiguration());
			modelBuilder.Configurations.Add(new UnitTypeDatabaseConfiguration());
			modelBuilder.Configurations.Add(new UtilityDatabaseConfiguration());
			modelBuilder.Configurations.Add(new ProjectDatabaseConfiguration());
		}
	}
}