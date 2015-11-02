namespace ArtistSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Artist
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string Country { get; set; }

        public DateTime BirthDate { get; set; }

        public virtual ICollection<Album> Albums { get; set; } 
    }
}