using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MoviesSystem.Common;

namespace MoviesSystem.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.MinTextLength)]
        [MaxLength(GlobalConstants.MidTextLength)]
        public string Name { get; set; }

        [Required]
        public GenderType Gender { get; set; }

        [Required]
        [Range(GlobalConstants.MinAge, GlobalConstants.MaxAge)]
        public int Age { get; set; }

        [Required]
        public int StudioId { get; set; }

        [ForeignKey("StudioId")]
        public virtual Studio Studio { get; set; }
    }
}