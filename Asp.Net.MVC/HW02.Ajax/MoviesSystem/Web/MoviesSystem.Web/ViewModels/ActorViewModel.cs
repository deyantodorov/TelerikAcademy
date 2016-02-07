using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AutoMapper;
using MoviesSystem.Common;
using MoviesSystem.Models;
using MoviesSystem.Web.Infrastructure.Mapping;

namespace MoviesSystem.Web.ViewModels
{
    public class ActorViewModel : IMapFrom<Actor>, IHaveCustomMappings
    {
        [UIHint("Input")]
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.MinTextLength)]
        [MaxLength(GlobalConstants.MidTextLength)]
        [UIHint("Input")]
        public string Name { get; set; }

        [Required]
        [UIHint("Select")]
        [Display(Name = "Gender")]
        public int GenderId { get; set; }

        public IEnumerable<SelectListItem> Genders { get; set; }

        [Required]
        [Range(GlobalConstants.MinAge, GlobalConstants.MaxAge)]
        [UIHint("Input")]
        public int Age { get; set; }

        [Required]
        [MinLength(GlobalConstants.MinTextLength)]
        [MaxLength(GlobalConstants.MidTextLength)]
        [UIHint("Input")]
        public string StudioName { get; set; }

        [Required]
        [MinLength(GlobalConstants.MinTextLength)]
        [MaxLength(GlobalConstants.MidTextLength)]
        [UIHint("Textarea")]
        public string StudioAddress { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Actor, ActorViewModel>()
                .ForMember(d => d.GenderId, opt => opt.MapFrom(s => s.Gender == GenderType.Male ? 1 : 0))
                .ForMember(d => d.StudioName, opt => opt.MapFrom(s => s.Studio.Name))
                .ForMember(d => d.StudioAddress, opt => opt.MapFrom(s => s.Studio.Address))
                .ReverseMap();
        }
    }
}