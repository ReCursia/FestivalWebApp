using AutoMapper;
using FestivalWebApp.Core.Models;
using FestivalWebApp.DAL.Models;

namespace FestivalWebApp.DAL.Mappings
{
    public class DataMappingProfile : Profile
    {
        public DataMappingProfile()
        {
            CreateMap<Festival, FestivalDatabaseModel>().ReverseMap();
            CreateMap<Participant, ParticipantDatabaseModel>().ReverseMap();
        }
    }
}