using System;
using System.Linq.Expressions;
using GTSharp.Domain.Entities;

namespace GTSharp.Domain.Queries
{
    public static class UserQueries
    {
        public static Expression<Func<User, bool>> ExpById(Guid id)
        {
            return o => o.Id == id;
        }
    }
}