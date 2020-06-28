using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GTSharp.Domain.Entities
{
    public class Player : Entity
    {
        [Required]
        [MinLength(3), MaxLength(100)]
        public string NickName { get; private set; }

        public string Avatar { get; private set; }

        [MinLength(2), MaxLength(2)]
        public string Country { get; private set; }

        public List<Score> Scores { get; private set; }

        public Guid IdUser { get; private set; }

        public Guid IdGame { get; private set; }

        public Player(string nickName, string avatar, string country, Guid idUser, Guid idGame)
        {
            NickName = nickName;
            Avatar = avatar;
            Country = country;
            Scores = new List<Score>();
            IdGame = idGame;
            IdUser = idUser;
        }
    }
}