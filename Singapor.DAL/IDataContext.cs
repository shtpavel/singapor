using System.Collections.Generic;
using System.Data.Entity;
using Singapor.Model.Entities;

namespace Singapor.DAL
{
    public interface IDataContext
    {
        IDbSet<T> Set<T>() where T: class;

        int SaveChanges();
    }
}