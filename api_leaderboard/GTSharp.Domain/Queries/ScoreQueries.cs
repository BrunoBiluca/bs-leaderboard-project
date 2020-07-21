using System;
using System.Linq.Expressions;
using GTSharp.Domain.Entities;

namespace GTSharp.Domain.Queries
{
    public static class ScoreQueries
    {
        public static Expression<Func<Score, bool>> ExpById(int id)
        {
            return o => o.Id == id;
        }

        public static Expression<Func<Score, bool>> ExpByTopRanking(int idGame, int count)
        {
            // return (o => o.GameId == idGame);
            return null;
        }
    }
}