using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTSharp.Domain.Entities
{
    public class Game : Entity
    {
        public string Title { get; private set; }

        public string Genre { get; private set; }

        public DateTime CreatedDate { get; private set; }

        public List<Player> Players { get; private set; }

        public Game(string title, string genre)
        {
            Title = title;
            Genre = genre;
            CreatedDate = DateTime.Today;
            Players = new List<Player>();
        }
    }
}