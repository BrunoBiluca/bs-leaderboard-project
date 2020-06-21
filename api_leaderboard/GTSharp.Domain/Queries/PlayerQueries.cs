using System;
using System.Linq.Expressions;
using GTSharp.Domain.Entities;

namespace GTSharp.Domain.Queries
{
    public static class PlayerQueries
    {
        public static Expression<Func<Player, bool>> ExpById(Guid id)
        {
            return o => o.Id == id;
        }
    }
}