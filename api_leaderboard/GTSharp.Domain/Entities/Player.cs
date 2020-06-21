using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTSharp.Domain.Entities
{
    public class Player : Entity
    {

        [MaxLength(100)]
        public string NickName { get; private set; }

        public string Avatar { get; private set; }

        public string Country { get; private set; }

        public Player(string nickName, string avatar, string country)
        {
            NickName = nickName;
            Avatar = avatar;
            Country = country;
        }
    }
}