﻿using System.Collections.Generic;
using System.Threading.Tasks;
using FestivalWebApp.Core.Models;

namespace FestivalWebApp.DAL.Contracts
{
    public interface IFestivalRepository
    {
        Task<Festival> GetFestivalById(int id);
        Task<IEnumerable<Festival>> GetAllFestivals();
        Task<Festival> AddFestival(Festival festival);
        Task UpdateFestival(Festival festival);
        Task RemoveFestival(Festival festival);
        Task<bool> IsExist(int id);
    }
}