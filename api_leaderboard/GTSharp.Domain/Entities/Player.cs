using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTSharp.Domain.Entities
{
    public class Player : Entity
    {
        [MaxLength(256)]
        public string Email { get; private set; }

        [MaxLength(256)]
        public string Name { get; private set; }

        [MaxLength(100)]
        public string NickName { get; private set; }

        public string Avatar { get; private set; }

        public string Country { get; private set; }

        public Player(string email, string name, string nickName, string avatar, string country)
        {
            Email = email;
            Name = name;
            NickName = nickName;
            Avatar = avatar;
            Country = country;
        }
    }
}