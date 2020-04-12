using System.Collections.Generic;
using FestivalWebApp.Domain.Models;

namespace FestivalWebApp.Domain.Repositories
{
    public interface IFestivalRepository
    {
        Festival GetFestivalById(int id);
        IEnumerable<Festival> GetAllFestivals();
        void AddFestival(Festival festival);
        void UpdateFestival(Festival festival);
        void RemoveFestival(Festival festival);
    }
}