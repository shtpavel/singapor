using System;
using System.Data.Entity;

namespace Singapor.DAL
{
    public interface IDataContext : IUnitOfWork
    {
        #region Public methods

        IDbSet<T> Set<T>() where T : class;

        #endregion
    }

    public interface IUnitOfWork : IDisposable
    {
        #region Public methods

        int SaveChanges();

        #endregion
    }
}