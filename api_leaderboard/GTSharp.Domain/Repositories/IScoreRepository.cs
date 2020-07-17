using System.Collections.Generic;
using GTSharp.Domain.Entities;

namespace GTSharp.Domain.Repositories
{
    public interface IScoreRepository
    {
        Score GetById(int id);
        IEnumerable<Score> GetAll();
        void Create(Score Score);
    }
}