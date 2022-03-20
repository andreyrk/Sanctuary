﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sanctuary.Domain.Entities
{
    [Table("Species")]
    public class Species
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

    }
}
