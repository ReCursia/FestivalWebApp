using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FestivalWebApp.Data.Database;
using FestivalWebApp.Data.Models;
using FestivalWebApp.Domain.Models;
using FestivalWebApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FestivalWebApp.Data.Repositores
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly FestivalDatabaseContext _context;
        private readonly IMapper _mapper;

        public ParticipantRepository(FestivalDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Participant GetParticipantById(int id)
        {
            var valueToMap = _context.Participants.Find(id);
            return _mapper.Map<ParticipantDatabaseModel, Participant>(valueToMap);
        }

        public IEnumerable<Participant> GetAllParticipants()
        {
            var valuesToMap = _context.Participants.AsEnumerable();
            return _mapper.Map<IEnumerable<ParticipantDatabaseModel>, IEnumerable<Participant>>(valuesToMap);
        }

        public IEnumerable<Participant> GetParticipantsByFestivalId(int festivalId)
        {
            var valuesToMap = _context.Participants.Include(p => p.Festival)
                .Where(p => p.FestivalId == festivalId)
                .AsEnumerable();
            return _mapper.Map<IEnumerable<ParticipantDatabaseModel>, IEnumerable<Participant>>(valuesToMap);
        }

        public void AddParticipant(Participant participant)
        {
            var mappedValue = _mapper.Map<Participant, ParticipantDatabaseModel>(participant);
            _context.Participants.Add(mappedValue);
        }

        public void UpdateParticipant(Participant participant)
        {
            var mappedValue = _mapper.Map<Participant, ParticipantDatabaseModel>(participant);
            _context.Participants.Update(mappedValue);
        }

        public void RemoveParticipant(Participant participant)
        {
            var mappedValue = _mapper.Map<Participant, ParticipantDatabaseModel>(participant);
            _context.Participants.Remove(mappedValue);
        }
    }
}