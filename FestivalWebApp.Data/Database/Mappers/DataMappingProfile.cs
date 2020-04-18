using AutoMapper;
using FestivalWebApp.Data.Models;
using FestivalWebApp.Domain.Models;

namespace FestivalWebApp.Data.Database.Mappers
{
    public class DataMappingProfile : Profile
    {
        public DataMappingProfile()
        {
            CreateMap<Festival, FestivalDatabaseModel>();
            CreateMap<Participant, ParticipantDatabaseModel>();

            //TODO make it reverse??
            CreateMap<FestivalDatabaseModel, Festival>();
            CreateMap<ParticipantDatabaseModel, Participant>();
        }
    }
}