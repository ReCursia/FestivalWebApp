using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FestivalWebApp.Data.Database;
using FestivalWebApp.Data.Models;
using FestivalWebApp.Domain.Models;
using FestivalWebApp.Domain.Repositories;

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

        public Festival GetFestivalById(int id)
        {
            var valueToMap = _context.Festivals.Find(id);
            return _mapper.Map<Festival>(valueToMap);
        }

        public IEnumerable<Festival> GetAllFestivals()
        {
            var valuesToMap = _context.Festivals.AsEnumerable();
            return _mapper.Map<IEnumerable<Festival>>(valuesToMap);
        }

        public void AddFestival(Festival festival)
        {
            var mappedValue = _mapper.Map<FestivalDatabaseModel>(festival);
            _context.Festivals.Add(mappedValue);
        }

        public void UpdateFestival(Festival festival)
        {
            var mappedValue = _mapper.Map<FestivalDatabaseModel>(festival);
            _context.Festivals.Update(mappedValue);
        }

        public void RemoveFestival(Festival festival)
        {
            var mappedValue = _mapper.Map<FestivalDatabaseModel>(festival);
            _context.Festivals.Remove(mappedValue);
        }
    }
}