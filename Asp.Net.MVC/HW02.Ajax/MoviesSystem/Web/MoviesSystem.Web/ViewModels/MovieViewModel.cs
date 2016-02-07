using System.ComponentModel.DataAnnotations;
using MoviesSystem.Common;
using MoviesSystem.Models;
using MoviesSystem.Web.Infrastructure.Mapping;

namespace MoviesSystem.Web.ViewModels
{
    public class MovieViewModel : IMapFrom<Movie>
    {
        [UIHint("Input")]
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.MinTextLength)]
        [MaxLength(GlobalConstants.LongTextLength)]
        [UIHint("Input")]
        public string Title { get; set; }

        [Required]
        [MinLength(GlobalConstants.MinTextLength)]
        [MaxLength(GlobalConstants.LongTextLength)]
        [UIHint("Input")]
        public string Director { get; set; }

        [Required]
        [Range(GlobalConstants.MinYear, GlobalConstants.MaxYear)]
        [UIHint("Input")]
        public int Year { get; set; }

        public ActorViewModel LeadingMaleRole { get; set; }

        public ActorViewModel LeadingFemaleRole { get; set; }
    }
}