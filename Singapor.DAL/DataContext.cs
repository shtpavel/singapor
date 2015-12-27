using System.Data.Entity;
using Singapor.DAL.Configurations;

namespace Singapor.DAL
{
    public class DataContext : DbContext, IDataContext
    {
        #region Constructors

        public DataContext() : base("")
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

            modelBuilder.Configurations.Add(new CompanyConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new UnitConfiguration());
            modelBuilder.Configurations.Add(new UnitScheduleConfiguration());
        }
    }
}