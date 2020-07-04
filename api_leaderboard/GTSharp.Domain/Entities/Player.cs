using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTSharp.Domain.Entities
{
    public class Player : Entity
    {
        [Required]
        [MinLength(3), MaxLength(64)]
        public string NickName { get; private set; }

        public string Avatar { get; private set; }

        [MinLength(2), MaxLength(2)]
        public string Country { get; private set; }

        public List<Score> Scores { get; private set; }

        [ForeignKey("User")]
        public int UserId { get; private set; }

        [ForeignKey("Game")]
        public int GameId { get; private set; }

        public Player() { }
        public Player(string nickName, string avatar, string country, int idUser, int idGame)
        {
            NickName = nickName;
            Avatar = avatar;
            Country = country;
            Scores = new List<Score>();
            GameId = idGame;
            UserId = idUser;
        }
    }
}