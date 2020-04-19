using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FestivalWebApp.Data.Database;
using FestivalWebApp.Data.Models;
using FestivalWebApp.Domain.Models;
using FestivalWebApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FestivalWebApp.Data.Repositories
{
    public class FestivalRepository : IFestivalRepository
    {
        private readonly FestivalDatabaseContext _context;
        private readonly IMapper _mapper;

        public FestivalRepository(FestivalDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Festival> GetFestivalById(int id)
        {
            var valueToMap = await _context.Festivals.FindAsync(id);
            return _mapper.Map<Festival>(valueToMap);
        }

        public async Task<IEnumerable<Festival>> GetAllFestivals()
        {
            var valuesToMap = await _context.Festivals.ToListAsync();
            return _mapper.Map<IEnumerable<Festival>>(valuesToMap);
        }

        public async Task<Festival> AddFestival(Festival festival)
        {
            var mappedValue = _mapper.Map<FestivalDatabaseModel>(festival);
            await _context.Festivals.AddAsync(mappedValue);
            await _context.SaveChangesAsync();
            return festival;
        }

        public async Task UpdateFestival(Festival festival)
        {
            var mappedValue = _mapper.Map<FestivalDatabaseModel>(festival);
            var festivalToUpdate = await GetFestivalById(mappedValue.Id);
            festivalToUpdate.Date = mappedValue.Date;
            festivalToUpdate.Description = mappedValue.Description;
            festivalToUpdate.Name = mappedValue.Name;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFestival(Festival festival)
        {
            var mappedValue = _mapper.Map<FestivalDatabaseModel>(festival);
            _context.Festivals.Remove(mappedValue);
            await _context.SaveChangesAsync();
        }
    }
}