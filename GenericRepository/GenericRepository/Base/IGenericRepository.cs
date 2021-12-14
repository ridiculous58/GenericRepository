using GenericRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GenericRepository.GenericRepository.Base
{
    public interface IGenericRepository<T> where T : class ,IEntity,new() 
    {
        T Get(int id);
        IEnumerable<T> Get(Expression<Func<T,bool>> filter = null); 
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
