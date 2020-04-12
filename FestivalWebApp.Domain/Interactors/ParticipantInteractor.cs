using System.Collections.Generic;
using FestivalWebApp.Domain.Models;
using FestivalWebApp.Domain.Repositories;

namespace FestivalWebApp.Domain.Interactors
{
    public class ParticipantInteractor : IParticipantInteractor
    {
        private readonly IParticipantRepository _repository;

        public ParticipantInteractor(IParticipantRepository repository)
        {
            _repository = repository;
        }

        public Participant GetParticipantById(int id)
        {
            return _repository.GetParticipantById(id);
        }

        public IEnumerable<Participant> GetAllParticipants()
        {
            return _repository.GetAllParticipants();
        }

        public IEnumerable<Participant> GetParticipantsByFestivalId(int festivalId)
        {
            return _repository.GetParticipantsByFestivalId(festivalId);
        }

        public void AddParticipant(Participant participant)
        {
            _repository.AddParticipant(participant);
        }

        public void UpdateParticipant(Participant participant)
        {
            _repository.UpdateParticipant(participant);
        }

        public void RemoveParticipant(Participant participant)
        {
            _repository.RemoveParticipant(participant);
        }
    }
}