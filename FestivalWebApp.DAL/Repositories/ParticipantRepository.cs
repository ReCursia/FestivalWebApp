using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FestivalWebApp.Core.Models;
using FestivalWebApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FestivalWebApp.DAL.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly FestivalDatabaseContext _context;

        public ParticipantRepository(FestivalDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Participant> GetParticipantById(int id)
        {
            return await _context.Participants.FindAsync(id);
        }

        public async Task<IEnumerable<Participant>> GetAllParticipants()
        {
            return await _context.Participants.ToListAsync();
        }

        public async Task<IEnumerable<Participant>> GetParticipantsByFestivalId(int festivalId)
        {
            return await _context.Participants.Where(p => p.FestivalId == festivalId)
                .ToListAsync();
        }

        public async Task<Participant> AddParticipant(Participant participant)
        {
            await _context.Participants.AddAsync(participant);
            await _context.SaveChangesAsync();
            return participant;
        }

        public async Task UpdateParticipant(Participant participant)
        {
            _context.Participants.Update(participant);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.Participants.FindAsync(id) != null;
        }

        public async Task RemoveParticipant(Participant participant)
        {
            _context.Participants.Remove(participant);
            await _context.SaveChangesAsync();
        }
    }
}