using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FestivalWebApp.Core.Models;
using FestivalWebApp.Core.Services;

namespace FestivalWebApp.BLL
{
    public class ParticipantService : IParticipantService
    {
        public Task<Participant> GetParticipantById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Participant>> GetAllParticipants()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Participant>> GetParticipantsByFestivalId(int festivalId)
        {
            throw new NotImplementedException();
        }

        public Task<Participant> AddParticipant(Participant participant)
        {
            throw new NotImplementedException();
        }

        public Task UpdateParticipant(Participant participant)
        {
            throw new NotImplementedException();
        }

        public Task RemoveParticipant(int id)
        {
            throw new NotImplementedException();
        }
    }
}