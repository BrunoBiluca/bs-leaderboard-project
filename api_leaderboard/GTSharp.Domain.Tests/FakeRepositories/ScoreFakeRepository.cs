using System.Collections.Generic;
using GTSharp.Domain.Commands.Input.CreateCommand;
using GTSharp.Domain.Entities;
using GTSharp.Domain.Repositories;

namespace GTSharp.Domain.Tests.FakeRepositories
{
    public class ScoreFakeRepository : IScoreRepository
    {
        Score Score1 = new Score("Fase 1", 1, 30, null, 1);
        Score Score2 = new Score("Fase 1", 1, 60, null, 1);

        public void Create(Score Score) { }

        public IEnumerable<Score> GetAll()
        {
            return new List<Score>() { Score1, Score2 };
        }

        public Score GetById(int id)
        {
            return Score1;
        }

    }
}
