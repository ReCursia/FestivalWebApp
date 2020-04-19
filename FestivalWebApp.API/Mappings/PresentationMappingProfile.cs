using AutoMapper;
using FestivalWebApp.API.Models;
using FestivalWebApp.Core.Models;

namespace FestivalWebApp.API.Mappings
{
    public class PresentationMappingProfile : Profile
    {
        public PresentationMappingProfile()
        {
            CreateMap<FestivalRequestBody, Festival>();
            CreateMap<ParticipantRequestBody, Participant>();
        }
    }
}