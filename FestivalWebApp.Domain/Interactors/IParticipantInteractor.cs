using System.Collections.Generic;
using FestivalWebApp.Domain.Models;

namespace FestivalWebApp.Domain.Interactors
{
    public interface IParticipantInteractor
    {
        Participant GetParticipantById(int id);
        IEnumerable<Participant> GetAllParticipants();
        IEnumerable<Participant> GetParticipantsByFestivalId(int festivalId);
        void AddParticipant(Participant participant);
        void UpdateParticipant(Participant participant);
        void RemoveParticipant(Participant participant);
    }
}