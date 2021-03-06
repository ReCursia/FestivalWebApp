﻿using System.Collections.Generic;
using System.Threading.Tasks;
using FestivalWebApp.Core.Models;

namespace FestivalWebApp.DAL.Contracts
{
    public interface IParticipantRepository
    {
        Task<Participant> GetParticipantById(int id);
        Task<IEnumerable<Participant>> GetAllParticipants();
        Task<IEnumerable<Participant>> GetParticipantsByFestivalId(int festivalId);
        Task<Participant> AddParticipant(Participant participant);
        Task UpdateParticipant(Participant participant);
        Task RemoveParticipant(Participant participant);
        Task<bool> IsExist(int id);
    }
}