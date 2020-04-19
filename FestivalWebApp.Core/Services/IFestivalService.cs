﻿using System.Collections.Generic;
using System.Threading.Tasks;
using FestivalWebApp.Domain.Models;

namespace FestivalWebApp.Core.Services
{
    public interface IFestivalService
    {
        Task<Festival> GetFestivalById(int id);
        
        Task<IEnumerable<Festival>> GetAllFestivals();
        
        Task<Festival> AddFestival(Festival festival);
        
        Task UpdateFestival(int id, Festival festival);
        
        Task RemoveFestival(Festival festival);
    }
}