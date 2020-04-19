using AutoMapper;
using FestivalWebApp.Data.Models;
using FestivalWebApp.Domain.Models;

namespace FestivalWebApp.Data.Database.Mappings
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