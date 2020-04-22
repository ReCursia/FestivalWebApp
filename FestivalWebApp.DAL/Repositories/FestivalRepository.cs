using System.Collections.Generic;
using System.Threading.Tasks;
using FestivalWebApp.Core.Models;
using FestivalWebApp.DAL.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FestivalWebApp.DAL.Repositories
{
    public class FestivalRepository : IFestivalRepository
    {
        private readonly FestivalDatabaseContext _context;

        public FestivalRepository(FestivalDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Festival> GetFestivalById(int id)
        {
            return await _context.Festivals.FindAsync(id);
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.Festivals.FindAsync(id) != null;
        }

        public async Task<IEnumerable<Festival>> GetAllFestivals()
        {
            return await _context.Festivals.ToListAsync();
        }

        public async Task<Festival> AddFestival(Festival festival)
        {
            await _context.Festivals.AddAsync(festival);
            await _context.SaveChangesAsync();
            return festival;
        }

        public async Task UpdateFestival(Festival festival)
        {
            _context.Festivals.Update(festival);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFestival(Festival festival)
        {
            _context.Festivals.Remove(festival);
            await _context.SaveChangesAsync();
        }
    }
}