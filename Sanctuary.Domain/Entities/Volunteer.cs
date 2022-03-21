using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sanctuary.Domain.Entities
{
    [Table("Volunteer")]
    public class Volunteer
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime Birthdate { get; set; }

        public string Role { get; set; }

        public string PasswordHash { get; set; }

        public string Status { get; set; }

    }
}
