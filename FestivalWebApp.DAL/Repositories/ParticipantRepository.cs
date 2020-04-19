using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FestivalWebApp.Data.Database;
using FestivalWebApp.Data.Models;
using FestivalWebApp.Domain.Models;
using FestivalWebApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FestivalWebApp.Data.Repositories
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

        public async Task<Participant> GetParticipantById(int id)
        {
            var valueToMap = await _context.Participants.FindAsync(id);
            return _mapper.Map<Participant>(valueToMap);
        }

        public async Task<IEnumerable<Participant>> GetAllParticipants()
        {
            var valuesToMap = await _context.Participants.ToListAsync();
            return _mapper.Map<IEnumerable<Participant>>(valuesToMap);
        }

        public async Task<IEnumerable<Participant>> GetParticipantsByFestivalId(int festivalId)
        {
            var valuesToMap = await _context.Participants.Include(p => p.Festival)
                .Where(p => p.FestivalId == festivalId)
                .ToListAsync();
            return _mapper.Map<IEnumerable<Participant>>(valuesToMap);
        }

        public async Task<Participant> AddParticipant(Participant participant)
        {
            var mappedValue = _mapper.Map<ParticipantDatabaseModel>(participant);
            await _context.Participants.AddAsync(mappedValue);
            return participant;
        }

        public async Task UpdateParticipant(Participant participant)
        {
            var mappedValue = _mapper.Map<ParticipantDatabaseModel>(participant);
            _context.Participants.Update(mappedValue);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveParticipant(Participant participant)
        {
            var mappedValue = _mapper.Map<ParticipantDatabaseModel>(participant);
            _context.Participants.Remove(mappedValue);
            await _context.SaveChangesAsync();
        }
    }
}