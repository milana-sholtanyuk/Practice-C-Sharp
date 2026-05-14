using System;
using System.ComponentModel.DataAnnotations;

namespace GuestBookApp.Models
{
    public class GuestEntry
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public int Rating { get; set; }

        public DateTime Date { get; set; }
    }
}