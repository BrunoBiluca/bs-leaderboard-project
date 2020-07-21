using System;
using System.Linq.Expressions;
using GTSharp.Domain.Entities;

namespace GTSharp.Domain.Queries
{
    public static class GameQueries
    {
        public static Expression<Func<Game, bool>> ExpById(int id)
        {
            return o => o.Id == id;
        }
    }
}