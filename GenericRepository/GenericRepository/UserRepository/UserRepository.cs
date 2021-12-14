using GenericRepository.GenericRepository.Base;
using GenericRepository.GenericRepository.Context;
using GenericRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GenericRepository.GenericRepository.UserRepository
{
    public class UserRepository : EfGenericRepository<User>,IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
