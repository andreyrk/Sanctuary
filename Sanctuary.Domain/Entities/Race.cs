using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sanctuary.Domain.Entities
{
    [Table("Race")]
    public class Race
    {
        [Key]
        public int Id { get; set; }

        public int SpeciesId { get; set; }

        public string Name { get; set; }
    }
}
