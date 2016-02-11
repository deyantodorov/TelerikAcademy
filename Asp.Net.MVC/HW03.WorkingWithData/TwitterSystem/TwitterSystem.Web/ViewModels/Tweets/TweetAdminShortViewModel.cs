using System.ComponentModel.DataAnnotations;
using AutoMapper;
using TwitterSystem.Models;
using TwitterSystem.Web.Infrastructure.Mapping;

namespace TwitterSystem.Web.ViewModels.Tweets
{
    public class TweetAdminShortViewModel : IMapFrom<Tweet>, IHaveCustomMappings
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string Content { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Tweet, TweetAdminShortViewModel>()
                .ForMember(d => d.Content, opt => opt.MapFrom(s => s.Content.Substring(0, 50)));
        }
    }
}