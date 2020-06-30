using System.Collections.Generic;
using GTSharp.Domain.Entities;
using GTSharp.Domain.Repositories;
using GTSharp.Domain.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using GTSharp.Domain.Queries;
using System;

namespace GTSharp.Domain.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public User GetById(int id)
        {
            return _context.User.FirstOrDefault(UserQueries.ExpById(id));
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User.AsNoTracking();
        }

        public void Create(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }
    }
}