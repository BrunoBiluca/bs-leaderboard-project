using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTSharp.Domain.Entities
{
    public class Score : Entity
    {
        [MinLength(3), MaxLength(64)]
        public string Title { get; private set; }
        //TODO: string / required
        public int? Stage { get; private set; }

        public int? Value { get; private set; }

        public DateTime? Time { get; private set; }

        public DateTime? CreateDate { get; private set; }

        //TODO: Player sem null
        [ForeignKey("Player")]
        public int? PlayerId { get; private set; }

        //TODO: Game sem null
        [ForeignKey("Game")]
        public int? GameId { get; private set; }

        public Score() { }

        public Score(string title, int? stage, int? value, DateTime? time, int? playerId, int? gameId)
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