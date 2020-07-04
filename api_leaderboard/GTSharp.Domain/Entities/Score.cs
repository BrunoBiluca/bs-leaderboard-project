using System;
using System.ComponentModel.DataAnnotations;

namespace GTSharp.Domain.Entities
{
    public class Score : Entity
    {
        [MinLength(3), MaxLength(64)]
        public string Title { get; private set; }

        public int? Stage { get; private set; }

        public DateTime? Time { get; private set; }

        public DateTime? CreateDate { get; private set; }

        public Score() { }

    }
}