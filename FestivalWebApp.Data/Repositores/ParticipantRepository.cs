﻿using System;
using System.Collections.Generic;
using FestivalWebApp.Data.Database;
using FestivalWebApp.Domain.Models;
using FestivalWebApp.Domain.Repositories;

namespace FestivalWebApp.Data.Repositores
{
    public class ParticipantRepository : IParticipantRepository
    {
        private FestivalDatabaseContext _context;

        public ParticipantRepository(FestivalDatabaseContext context)
        {
            _context = context;
        }

        public Participant GetParticipantById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Participant> GetAllParticipants()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Participant> GetParticipantsByFestivalId(int festivalId)
        {
            throw new NotImplementedException();
        }

        public void AddParticipant(Participant participant)
        {
            throw new NotImplementedException();
        }

        public void UpdateParticipant(Participant participant)
        {
            throw new NotImplementedException();
        }

        public void RemoveParticipant(Participant participant)
        {
            throw new NotImplementedException();
        }
    }
}