using System;
using System.ComponentModel.DataAnnotations;

namespace GTSharp.Domain.Entities
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; private set; }


    }
}