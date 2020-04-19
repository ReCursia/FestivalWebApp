using System.Collections.Generic;
using System.Threading.Tasks;
using FestivalWebApp.BLL.Exceptions;
using FestivalWebApp.Core.Models;
using FestivalWebApp.Core.Repositories;
using FestivalWebApp.Core.Services;

namespace FestivalWebApp.BLL
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _repository;

        public ParticipantService(IParticipantRepository repository)
        {
            _repository = repository;
        }

        public async Task<Participant> GetParticipantById(int id)
        {
            return await _repository.GetParticipantById(id);
        }

        public async Task<IEnumerable<Participant>> GetAllParticipants()
        {
            return await _repository.GetAllParticipants();
        }

        public async Task<IEnumerable<Participant>> GetParticipantsByFestivalId(int festivalId)
        {
            return await _repository.GetParticipantsByFestivalId(festivalId);
        }

        public async Task<Participant> AddParticipant(Participant participant)
        {
            return await _repository.AddParticipant(participant);
        }

        public async Task UpdateParticipant(Participant participant)
        {
            var isExist = await _repository.IsExist(participant.Id);
            if (!isExist) throw new ElementNotFoundException(participant);

            await _repository.UpdateParticipant(participant);
        }

        public async Task RemoveParticipant(int id)
        {
            var isExist = await _repository.IsExist(id);
            if (!isExist) throw new ElementNotFoundException(id);

            var participant = await GetParticipantById(id);
            await _repository.RemoveParticipant(participant);
        }
    }
}