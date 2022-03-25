using System;
using System.ComponentModel.DataAnnotations;

namespace Sanctuary.Presentation.Models
{
    public class AnimalsViewModel
    {
        public int Id { get; set; }
        
        [Required]
        public int RaceId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool Sex { get; set; }

        public DateTime Birthdate { get; set; }

        [Required]
        public bool HasBirthdate { get; set; }

        [Required]
        public bool HasAccurateBirthdate { get; set; }
    }
}
