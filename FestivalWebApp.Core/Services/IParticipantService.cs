using System.Collections.Generic;
using System.Threading.Tasks;
using FestivalWebApp.Domain.Models;

namespace FestivalWebApp.Core.Services
{
    public interface IParticipantService
    {
        Task<Participant> GetParticipantById(int id);
        
        Task<IEnumerable<Participant>> GetAllParticipants();
        
        Task<IEnumerable<Participant>> GetParticipantsByFestivalId(int festivalId);
        
        Task<Participant> AddParticipant(Participant participant);
        
        Task UpdateParticipant(int id, Participant participant);
        
        Task RemoveParticipant(Participant participant);
    }
}