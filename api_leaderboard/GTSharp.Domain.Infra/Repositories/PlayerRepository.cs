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
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DataContext _context;

        public PlayerRepository(DataContext context)
        {
            _context = context;
        }

        public Player GetById(int id)
        {
            return _context.Player.FirstOrDefault(PlayerQueries.ExpById(id));
        }

        public IEnumerable<Player> GetAll()
        {
            return _context.Player.AsNoTracking();
        }

        public void Create(Player player)
        {
            _context.Player.Add(player);
            _context.SaveChanges();
        }
    }
}