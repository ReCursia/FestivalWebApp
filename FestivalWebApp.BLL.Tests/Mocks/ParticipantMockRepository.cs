using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FestivalWebApp.Core.Models;
using FestivalWebApp.DAL.Contracts;

namespace FestivalWebApp.BLL.Tests.Mocks
{
    public class ParticipantMockRepository : IParticipantRepository
    {
        private readonly Dictionary<int, Participant> _dict = new Dictionary<int, Participant>();

        public Task UpdateParticipant(Participant participant)
        {
            return Task.FromResult(_dict[participant.Id] = participant);
        }

        public Task RemoveParticipant(Participant participant)
        {
            return Task.FromResult(_dict.Remove(participant.Id));
        }

        public Task<bool> IsExist(int id)
        {
            return Task.FromResult(_dict.ContainsKey(id));
        }

        public Task<Participant> GetParticipantById(int id)
        {
            return Task.FromResult(_dict[id]);
        }

        public Task<IEnumerable<Participant>> GetAllParticipants()
        {
            return Task.FromResult<IEnumerable<Participant>>(_dict.Values);
        }

        public Task<IEnumerable<Participant>> GetParticipantsByFestivalId(int festivalId)
        {
            return Task.FromResult(_dict.Values.Where(p => p.FestivalId == festivalId));
        }

        public Task<Participant> AddParticipant(Participant participant)
        {
            _dict[participant.Id] = participant;
            return Task.FromResult(participant);
        }
    }
}