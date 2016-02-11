using System;
using System.ComponentModel.DataAnnotations;
using TwitterSystem.Models;
using TwitterSystem.Web.Infrastructure.Mapping;

namespace TwitterSystem.Web.ViewModels.Comments
{
    public class CommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public int TweetId { get; set; }
    }
}