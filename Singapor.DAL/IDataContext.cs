using System.Collections.Generic;
using System.Data.Entity;
using Singapor.Model.Entities;

namespace Singapor.DAL
{
    public interface IDataContext
    {
        DbSet<T> Set<T>() where T: class ;

        int SaveChanges();
    }
}