using System;
using System.Collections.Generic;
using GTSharp.Domain.Entities;

namespace GTSharp.Domain.Repositories
{
    public interface IUserRepository
    {
        User GetById(Guid id);
        IEnumerable<User> GetAll();
        void Create(User user);
    }
}