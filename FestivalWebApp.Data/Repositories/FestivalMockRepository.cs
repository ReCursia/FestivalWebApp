using System.Collections.Generic;
using FestivalWebApp.Domain.Models;
using FestivalWebApp.Domain.Repositories;

namespace FestivalWebApp.Data.Repositories
{
    public class FestivalMockRepository : IFestivalRepository
    {
        private readonly Dictionary<int, Festival> _dictionary = new Dictionary<int, Festival>();

        public Festival GetFestivalById(int id)
        {
            return _dictionary[id];
        }

        public IEnumerable<Festival> GetAllFestivals()
        {
            return _dictionary.Values;
        }

        public void AddFestival(Festival festival)
        {
            _dictionary[festival.Id] = festival;
        }

        public void UpdateFestival(Festival festival)
        {
            _dictionary[festival.Id] = festival;
        }

        public void RemoveFestival(Festival festival)
        {
            _dictionary.Remove(festival.Id);
        }
    }
}