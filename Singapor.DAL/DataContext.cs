using System.Data.Entity;
using Singapor.DAL.Configurations;

namespace Singapor.DAL
{
    public class DataContext : DbContext, IDataContext
    {
        #region Constructors

        public DataContext() : base("name=Default")
        {
            Database.SetInitializer(new DatabaseInintializer());
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

            modelBuilder.Configurations.Add(new CompanyConfiguration());
            modelBuilder.Configurations.Add(new UnitConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UnitTypeConfiguration());
            modelBuilder.Configurations.Add(new ServiceConfiguration());
        }
    }
}