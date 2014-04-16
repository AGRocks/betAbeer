using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace BetABeer.Model.Utilities
{
    public interface IDbDataProvider : IUnitOfWork
    {
        IQueryable<T> GetDbSetAsQueryable<T>() where T : class;
        DbSet<T> GetDbSet<T>() where T : class;
        DbEntityEntry<T> ContextEntry<T>(T entity) where T : class;
    }
}