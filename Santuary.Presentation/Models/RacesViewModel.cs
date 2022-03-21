using System;
using System.ComponentModel.DataAnnotations;

namespace Sanctuary.Presentation.Models
{
    public class RacesViewModel
    {
        public int Id { get; set; }

        public int SpeciesId { get; set; }

        public string Name { get; set; }
    }
}
