using System;
using System.ComponentModel.DataAnnotations;

namespace Sanctuary.Presentation.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(64)]
        public string Email { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [Required]
        [StringLength(16)]
        public string Phone { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }
    }
}
