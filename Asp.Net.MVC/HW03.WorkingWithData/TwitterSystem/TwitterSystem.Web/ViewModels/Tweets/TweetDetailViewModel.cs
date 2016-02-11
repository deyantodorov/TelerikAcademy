using System;
using System.Collections.Generic;
using TwitterSystem.Models;
using TwitterSystem.Web.Infrastructure.Mapping;
using TwitterSystem.Web.ViewModels.Comments;

namespace TwitterSystem.Web.ViewModels.Tweets
{
    public class TweetDetailViewModel : IMapFrom<Tweet>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }
    }
}