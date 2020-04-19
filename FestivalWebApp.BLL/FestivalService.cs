using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FestivalWebApp.Core.Models;
using FestivalWebApp.Core.Services;

namespace FestivalWebApp.BLL
{
    public class FestivalService : IFestivalService
    {
        public Task<Festival> GetFestivalById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Festival>> GetAllFestivals()
        {
            throw new NotImplementedException();
        }

        public Task<Festival> AddFestival(Festival festival)
        {
            throw new NotImplementedException();
        }

        public Task UpdateFestival(int id, Festival festival)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFestival(Festival festival)
        {
            throw new NotImplementedException();
        }
    }
}