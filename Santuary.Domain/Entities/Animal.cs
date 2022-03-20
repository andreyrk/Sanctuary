using System;
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

        public string Species { get; set; }

        public bool Sex { get; set; }

        public short Age { get; set; }

    }
}
