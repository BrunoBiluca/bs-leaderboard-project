using System.Collections.Generic;
using GTSharp.Domain.Commands.Input.CreateCommand;
using GTSharp.Domain.Entities;
using GTSharp.Domain.Repositories;

namespace GTSharp.Domain.Tests.FakeRepositories
{
    public class GameFakeRepository : IGameRepository
    {
        Game game1 = new Game("Batman", "Hero");
        Game game2 = new Game("Bruce Wayne", "Hero");

        public void Create(Game game) { }

        public IEnumerable<Game> GetAll()
        {
            return new List<Game>() { game1, game2 };
        }

        public Game GetById(int id)
        {
            return game1;
        }

    }
}
