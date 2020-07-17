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
    public class GameRepository : IGameRepository
    {
        private readonly DataContext _context;

        public GameRepository(DataContext context)
        {
            _context = context;
        }

        public Game GetById(int id)
        {
            return _context.Game.FirstOrDefault(GameQueries.ExpById(id));
        }

        public IEnumerable<Game> GetAll()
        {
            return _context.Game.AsNoTracking();
        }

        public void Create(Game Game)
        {
            _context.Game.Add(Game);
            _context.SaveChanges();
        }
    }
}