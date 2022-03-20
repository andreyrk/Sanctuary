using System;
using System.ComponentModel.DataAnnotations;

namespace Sanctuary.Presentation.Models
{
    public class AnimalsViewModel
    {
        public string Name { get; set; }
        
        public int SpeciesId { get; set; }

        public bool Sex { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
