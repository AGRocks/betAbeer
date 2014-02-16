using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace BetABeer.Model.Utilities
{
    public interface IRepository<T> : IUnitOfWork
    {
        void Insert(T entity);
        void Delete(T entity);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetById(long id);
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        void Attach(T entity);
    }

    public class Repository<T> : IRepository<T> where T : class, IClientEntity
    {
        private DbSet<T> context;
        private IUnitOfWork _unitOfWork;

        public Repository(IDbDataProvider dataProvider)
        {
            context = dataProvider.GetDbSet<T>();
            _unitOfWork = dataProvider as IUnitOfWork;
        }

        public void Insert(T entity)
        {
            context.Add(entity);
        }

        public void Delete(T entity)
        {
            context.Remove(entity);            
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return context.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return context.AsQueryable();
        }

        public T GetById(long id)
        {
            return context.FirstOrDefault(x => x.Id == id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return context.FirstOrDefault(predicate);
        }

        public void Attach(T entity)
        {
            context.Attach(entity);
        }

        #region IUnitOfWork Members

        public void Save()
        {
            if (_unitOfWork != null)
                _unitOfWork.Save();
        }

        public Task SaveAsync()
        {
            if (_unitOfWork != null)
                return _unitOfWork.SaveAsync();

            return Task.Delay(0);
        }

        #endregion
    }
}