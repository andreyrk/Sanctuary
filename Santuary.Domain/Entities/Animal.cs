﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sanctuary.Domain.Entities
{
    [Table("Animal")]
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int SpeciesId { get; set; }

        public bool Sex { get; set; }

        public DateTime Birthdate { get; set; }

    }
}
