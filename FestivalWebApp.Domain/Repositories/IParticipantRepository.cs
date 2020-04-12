using System.Collections.Generic;
using FestivalWebApp.Domain.Models;

namespace FestivalWebApp.Domain.Repositories
{
    public interface IParticipantRepository
    {
        Participant GetParticipantById(int id);
        IEnumerable<Participant> GetAllParticipants();
        IEnumerable<Participant> GetParticipantsByFestivalId(int festivalId);
        void AddParticipant(Participant participant);
        void UpdateParticipant(Participant participant);
        void RemoveParticipant(Participant participant);
    }
}