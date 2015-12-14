using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.DAL.Configurations;
using Singapor.Model.Entities;

namespace Singapor.DAL
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext() : base("")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CompanyConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new UnitConfiguration());
            modelBuilder.Configurations.Add(new UnitScheduleConfiguration());
        }

        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
