using System;
using System.ComponentModel.DataAnnotations;

namespace GTSharp.Domain.Entities
{
    public class Score : Entity
    {
        public string ScoreJSON { get; private set; }
        public DateTime? CreateDate { get; private set; }

        public Score() { }
        public Score(string scoreJSON, DateTime createDate)
        {
            ScoreJSON = string.Empty;
        }
    }
}