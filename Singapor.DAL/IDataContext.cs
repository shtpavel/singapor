using System;
using System.Collections.Generic;
using System.Data.Entity;
using Singapor.Model.Entities;

namespace Singapor.DAL
{
    public interface IDataContext : IUnitOfWork
    {
        IDbSet<T> Set<T>() where T: class;

    }

    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }
}