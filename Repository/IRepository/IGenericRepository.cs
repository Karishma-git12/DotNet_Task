﻿using System.Linq.Expressions;

namespace Developer_Task.Repository.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(int id);

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );

        T FirstOrDefault(
             Expression<Func<T, bool>> filter = null,
             string includeProperties = null
            );

        void Add(T entity);
        void Remove(T entity);
        void Remove(int id);
        void RemoveRange(IEnumerable<T> entities);
    }
}
