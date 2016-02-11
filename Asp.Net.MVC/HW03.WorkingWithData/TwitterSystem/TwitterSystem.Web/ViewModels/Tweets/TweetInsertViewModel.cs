using System.ComponentModel.DataAnnotations;
using TwitterSystem.Models;
using TwitterSystem.Web.Infrastructure.Mapping;

namespace TwitterSystem.Web.ViewModels.Tweets
{
    public class TweetInsertViewModel : IMapFrom<Tweet>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tweet content: ")]
        [MinLength(2)]
        [MaxLength(255)]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Tags separated with space: ")]
        [MinLength(2)]
        [MaxLength(200)]
        public string Tags { get; set; }
    }
}