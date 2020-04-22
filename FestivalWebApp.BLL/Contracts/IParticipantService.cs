using System.Collections.Generic;
using System.Threading.Tasks;
using FestivalWebApp.Core.Models;

namespace FestivalWebApp.BLL.Contracts
{
    public interface IParticipantService
    {
        Task<Participant> GetParticipantById(int id);

        Task<IEnumerable<Participant>> GetAllParticipants();

        Task<IEnumerable<Participant>> GetParticipantsByFestivalId(int festivalId);

        Task<Participant> AddParticipant(Participant participant);

        Task UpdateParticipant(Participant participant);

        Task RemoveParticipant(int id);
    }
}