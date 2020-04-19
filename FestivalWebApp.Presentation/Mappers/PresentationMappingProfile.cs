using AutoMapper;
using FestivalWebApp.Domain.Models;
using FestivalWebApp.Presentation.Models;

namespace FestivalWebApp.Presentation.Mappers
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