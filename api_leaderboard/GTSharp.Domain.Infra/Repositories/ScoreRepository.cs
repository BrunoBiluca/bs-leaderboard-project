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
    public class ScoreRepository : IScoreRepository
    {
        private readonly DataContext _context;

        public ScoreRepository(DataContext context)
        {
            _context = context;
        }

        public Score GetById(int id)
        {
            return _context.Score.FirstOrDefault(ScoreQueries.ExpById(id));
        }

        public IEnumerable<Score> GetAll()
        {
            return _context.Score.AsNoTracking();
        }

        public void Create(Score Score)
        {
            _context.Score.Add(Score);
            _context.SaveChanges();
        }
    }
}