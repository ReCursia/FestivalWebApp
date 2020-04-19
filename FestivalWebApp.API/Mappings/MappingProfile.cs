﻿using AutoMapper;
using FestivalWebApp.API.Models;
using FestivalWebApp.Core.Models;

namespace FestivalWebApp.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FestivalRequestBody, Festival>();
            CreateMap<ParticipantRequestBody, Participant>();
        }
    }
}