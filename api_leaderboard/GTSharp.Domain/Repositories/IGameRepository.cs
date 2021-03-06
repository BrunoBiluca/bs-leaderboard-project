using System;
using System.Collections.Generic;
using GTSharp.Domain.Entities;

namespace GTSharp.Domain.Repositories
{
    public interface IGameRepository
    {
        Game GetById(int id);
        IEnumerable<Game> GetAll();
        void Create(Game game);
    }
}