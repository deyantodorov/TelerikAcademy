using System.ComponentModel.DataAnnotations;
using TwitterSystem.Models;
using TwitterSystem.Web.Infrastructure.Mapping;

namespace TwitterSystem.Web.ViewModels.Tweets
{
    public class TweetEditViewModel : IMapFrom<Tweet>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string Content { get; set; }
    }
}