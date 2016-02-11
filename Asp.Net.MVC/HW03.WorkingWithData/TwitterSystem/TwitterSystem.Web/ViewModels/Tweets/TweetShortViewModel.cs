using System;
using AutoMapper;
using TwitterSystem.Models;
using TwitterSystem.Web.Infrastructure.Mapping;

namespace TwitterSystem.Web.ViewModels.Tweets
{
    public class TweetShortViewModel : IMapFrom<Tweet>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CretedOn { get; set; }

        public int CommentsCount { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Tweet, TweetShortViewModel>()
                .ForMember(d => d.CommentsCount, opt => opt.MapFrom(s => s.Comments.Count));
        }
    }
}