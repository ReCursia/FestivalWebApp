using System;
using System.Collections.Generic;
using FestivalWebApp.Data.Database;
using FestivalWebApp.Domain.Models;
using FestivalWebApp.Domain.Repositories;

namespace FestivalWebApp.Data.Repositores
{
    public class FestivalRepository : IFestivalRepository
    {
        private FestivalDatabaseContext _context;

        public FestivalRepository(FestivalDatabaseContext context)
        {
            _context = context;
        }

        public Festival GetFestivalById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Festival> GetAllFestivals()
        {
            throw new NotImplementedException();
        }

        public void AddFestival(Festival festival)
        {
            throw new NotImplementedException();
        }

        public void UpdateFestival(Festival festival)
        {
            throw new NotImplementedException();
        }

        public void RemoveFestival(Festival festival)
        {
            throw new NotImplementedException();
        }
    }
}