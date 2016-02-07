using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MoviesSystem.Common;

namespace MoviesSystem.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.MinTextLength)]
        [MaxLength(GlobalConstants.LongTextLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(GlobalConstants.MinTextLength)]
        [MaxLength(GlobalConstants.LongTextLength)]
        public string Director { get; set; }

        [Required]
        [Range(GlobalConstants.MinYear, GlobalConstants.MaxYear)]
        public int Year { get; set; }
        
        public int LeadingMaleRoleId { get; set; }

        [ForeignKey("LeadingMaleRoleId")]
        public virtual Actor LeadingMaleRole { get; set; }

        public int LeadingFemaleRoleId { get; set; }

        [ForeignKey("LeadingFemaleRoleId")]
        public virtual Actor LeadingFemaleRole { get; set; }
    }
}