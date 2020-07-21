using System;
using System.Collections.Generic;
using GTSharp.Domain.Entities;

namespace GTSharp.Domain.Repositories
{
    public interface IPlayerRepository
    {
        Player GetById(int id);
        IEnumerable<Player> GetAll();
        void Create(Player player);
    }
}