using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTSharp.Domain.Entities
{
    public class Score : Entity
    {
        [MinLength(3), MaxLength(64)]
        public string Title { get; private set; }

        [MinLength(1), MaxLength(64)]
        public string Stage { get; private set; }

        public int? Value { get; private set; }

        public DateTime? Time { get; private set; }

        public DateTime? CreateDate { get; private set; }

        [ForeignKey("Player")]
        public int? PlayerId { get; private set; }

        [ForeignKey("Game")]
        public int? GameId { get; private set; }

        public Score() { }

        public Score(string title, string stage, int? value, DateTime? time, int? playerId, int? gameId)
        {
            Title = title;
            Stage = stage;
            Value = value;
            Time = time;
            CreateDate = DateTime.Now;
            PlayerId = playerId;
            GameId = gameId;
        }
    }
}