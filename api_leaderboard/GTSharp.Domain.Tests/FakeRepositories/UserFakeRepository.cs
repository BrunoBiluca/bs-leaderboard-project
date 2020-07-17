using System.Collections.Generic;
using GTSharp.Domain.Entities;
using GTSharp.Domain.Repositories;

namespace GTSharp.Domain.Tests.FakeRepositories
{
    public class UserFakeRepository : IUserRepository
    {
        User User1 = new User("brucewayne@gmail.com", "Bruce", "Bat.png", "Batman", "guest.png", "CO");
        User User2 = new User("jull@gmail.com", "Júlio", "Jull.png", "Jull", "guest.png", "BR");

        public void Create(User User) { }

        public IEnumerable<User> GetAll()
        {
            return new List<User>() { User1, User2 };
        }

        public User GetById(int id)
        {
            return User1;
        }
    }
}
