using System;
using System.ComponentModel.DataAnnotations;

namespace Sanctuary.Presentation.Models
{
    [Serializable]
    public class SpeciesViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
