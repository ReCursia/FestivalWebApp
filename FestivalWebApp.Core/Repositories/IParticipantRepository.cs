using System.Collections.Generic;
using System.Threading.Tasks;
using FestivalWebApp.Domain.Models;

namespace FestivalWebApp.Domain.Repositories
{
    public interface IParticipantRepository
    {
        Task<Participant> GetParticipantById(int id);
        Task<IEnumerable<Participant>> GetAllParticipants();
        Task<IEnumerable<Participant>> GetParticipantsByFestivalId(int festivalId);
        Task<Participant> AddParticipant(Participant participant);
        Task UpdateParticipant(Participant participant);
        Task RemoveParticipant(Participant participant);
    }
}