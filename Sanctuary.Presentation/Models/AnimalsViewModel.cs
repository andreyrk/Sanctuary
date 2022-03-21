using System;
using System.ComponentModel.DataAnnotations;

namespace Sanctuary.Presentation.Models
{
    public class AnimalsViewModel
    {
        public int Id { get; set; }
        
        public int RaceId { get; set; }

        public string Name { get; set; }

        public bool Sex { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
