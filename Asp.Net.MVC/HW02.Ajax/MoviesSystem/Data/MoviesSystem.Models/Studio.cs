using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MoviesSystem.Common;

namespace MoviesSystem.Models
{
    public class Studio
    {
        private ICollection<Actor> actors;

        public Studio()
        {
            this.actors = new HashSet<Actor>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.MinTextLength)]
        [MaxLength(GlobalConstants.MidTextLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(GlobalConstants.MinTextLength)]
        [MaxLength(GlobalConstants.MidTextLength)]
        public string Address { get; set; }

        public ICollection<Actor> Actors
        {
            get { return this.actors; }
            set { this.actors = value; }
        }
    }
}