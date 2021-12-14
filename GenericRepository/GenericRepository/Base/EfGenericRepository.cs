using GenericRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GenericRepository.GenericRepository.Base
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext _dbContext;
        public EfGenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual T Add(T entity)
        {
            // _dbContext.Set<T>().Add(entity);
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public virtual void Delete(T entity)
        {
            throw new NotImplementedException();
            // client =>  Server => DTO  (Password,RE-Password) => Model Password = dto.Password 
        }

        public virtual T Get(int id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public virtual T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
