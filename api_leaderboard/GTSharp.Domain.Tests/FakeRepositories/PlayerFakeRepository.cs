using System.Collections.Generic;
using GTSharp.Domain.Commands.Input.CreateCommand;
using GTSharp.Domain.Entities;
using GTSharp.Domain.Repositories;

namespace GTSharp.Domain.Tests.FakeRepositories
{
    public class PlayerFakeRepository : IPlayerRepository
    {
        Player Player1 = new Player("Batman", "Bat.png", "AR", 1, 1);
        Player Player2 = new Player("Bruce Wayne", "Bruce.png", "BR", 1, 1);

        public void Create(Player Player) { }

        public IEnumerable<Player> GetAll()
        {
            return new List<Player>() { Player1, Player2 };
        }

        public Player GetById(int id)
        {
            return Player1;
        }

    }
}
